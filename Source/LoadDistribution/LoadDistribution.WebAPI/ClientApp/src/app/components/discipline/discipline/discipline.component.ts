import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { map, mergeMap } from 'rxjs/operators';
import ActivityClient from 'src/app/clients/activityClient.client';
import DisciplineActivityMapClient from 'src/app/clients/disciplineActivityMapClient.client';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import OperationManager from 'src/app/helpers/operationManager.helper';
import ActivityDTO from 'src/app/models/dto/models/activityDTO.model';
import DisciplineActivityMapDTO from 'src/app/models/dto/models/disciplineActivityMapDTO.model';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';
import { DependencyType } from 'src/app/models/enums/dependencyType.enum';
import ActivityCalculation from 'src/app/models/helpers/models/activityCalculation.model';
import CalculationResult from 'src/app/models/helpers/models/calculationResult.model';
import DisciplineCalculation from 'src/app/models/helpers/models/disciplineCalculation.model';
import Localizable from 'src/app/models/helpers/models/localizable.model';
import CalculationService from 'src/app/services/calculation.service';
import EnumService from 'src/app/services/enum.service';

@Component({
  selector: 'app-discipline',
  templateUrl: './discipline.component.html',
  styleUrls: ['./discipline.component.scss']
})
export class DisciplineComponent extends CUComponent<DisciplineDTO> {
  private _activities: ActivityDTO[];

  calculationResult$: Observable<CalculationResult>;

  dependencyTypes: Localizable<number>[] = this._enumService.toLocalizables("dependencyType", DependencyType);
  universities$: Observable<UniversityDTO[]> = this._universityClient.getAll();
  
  operationManager = new OperationManager<DisciplineActivityMapDTO>(
    this._disciplineActivityMapClient,
    dto => this._initDisciplineActivityMapForm(dto)
  );

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    private readonly _disciplineActivityMapClient: DisciplineActivityMapClient,
    private readonly _disciplineClient: DisciplineClient,
    private readonly _activityClient: ActivityClient,
    private readonly _enumService: EnumService,
    private readonly _calculationService: CalculationService,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(_disciplineClient, activatedRoute, router, '/disciplines');

    this.id$.subscribe(id => this._onIdChanged(id));
    this._activityClient.getAll().subscribe(a => this._activities = a);
  }

  ngOnInit(): void {
    super.ngOnInit();
    this._initFormSubscriptions();
  }

  onCreateButtonClick(): void {
    this._disciplineClient
      .insert(this._payloadMapper())
      .pipe(
        mergeMap(({id}) => {
          return this.operationManager.synchronize((dto, form) => { 
            return {...dto, ...form.value, disciplineId: id, disciplineActivityMaps: null};
          });
        })
      ).subscribe(() => {
        this.operationManager.clear();
        this._initForm();
      });
  }

  onCreateAndReturnButtonClick(returnUrl: string | null = null): void {
    this._disciplineClient
        .insert(this._payloadMapper())
        .pipe(
          mergeMap(({id}) => {
            return this.operationManager.synchronize((dto, form) => {
              return {...dto, ...form.value, disciplineId: id, disciplineActivityMaps: null};
            });
          })
        ).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  onUpdateButtonClick(): void {
    forkJoin([
      this._disciplineClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, disciplineId: this.base.id, disciplineActivityMaps: null};
      })
    ]).subscribe(() => {
      this.operationManager.clear();
      this._initForm();
      this._tryLoadData(this.base.id);
    });
  }

  onUpdateAndReturnButtonClick(returnUrl: string | null = null): void {
    forkJoin([
      this._disciplineClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, disciplineId: this.base.id, disciplineActivityMaps: null};
      })
    ]).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  filterActivities(control: FormGroup): ActivityDTO[] {
    return this._activities.filter(a => !this.operationManager.controls.some(c => c != control && c.value.activityId == a.id));
  }

  protected _payloadMapper(): any {
    return {...this.base, ...this.form.value, university: null};
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(null, [Validators.required]),
      type: new FormControl(null),
      term: new FormControl(null, [Validators.required]),
      educationLevel: new FormControl(null),
      educationForm: new FormControl(null, [Validators.required]),
      planIndex: new FormControl(null, [Validators.required]),
      speciality: new FormControl(null, [Validators.required]),
      groupAbbreviation: new FormControl(null, [Validators.required]),
      specialization: new FormControl(null, [Validators.required]),
      institute: new FormControl(null),
      course: new FormControl(null, [Validators.required]),
      studentCount: new FormControl(null, [Validators.required, Validators.min(0)]),
      budgetStudentCount: new FormControl(null, [Validators.required, Validators.min(0)]),
      comercialStudentCount: new FormControl(null, [Validators.required, Validators.min(0)]),
      groupCount: new FormControl(null, [Validators.required, Validators.min(0)]),
      subgroupCount: new FormControl(null, [Validators.required, Validators.min(0)]),
      threadCount: new FormControl(null, [Validators.required, Validators.min(0)]),
      universityId: new FormControl(null, [Validators.required]),
      disciplineActivityMaps: this.operationManager.formArray
    });
  }

  private _initDisciplineActivityMapForm(dto: DisciplineActivityMapDTO | null): FormGroup {
    return this._formBuilder.group({
      activityId: new FormControl(dto?.activityId, [Validators.required]),
      value: new FormControl(dto?.value, [Validators.required, Validators.min(0)])
    });
  }

  private _onIdChanged(id: number): void {
    this._disciplineActivityMapClient.search(id).subscribe(dams => 
      this.operationManager.addRange(dams)
    );
  }

  private _initFormSubscriptions(): void {
    
    this.calculationResult$ = this.form.valueChanges.pipe(
      map(v => {
        // computing student count
        v.studentCount = v.comercialStudentCount > 0 && v.budgetStudentCount > 0 ? v.comercialStudentCount + v.budgetStudentCount : 0;
        this.form.patchValue({studentCount: v.studentCount}, {emitEvent: false});
  
        // calculating hours
        const discipline = new DisciplineCalculation(v.studentCount, v.groupCount, v.subgroupCount, v.threadCount, v.comercialStudentCount, v.budgetStudentCount);
        const activities: ActivityCalculation[] = [];
        
        for(const dam of v.disciplineActivityMaps) {
          const activity = this._activities.find(a => a.id == dam.activityId);
          if (!activity) {
            continue;
          }

          activities.push(new ActivityCalculation(activity.dependencyType, dam.value));
        }

        return this._calculationService.calculateAll(discipline, activities);
      })
    );

  }
}
