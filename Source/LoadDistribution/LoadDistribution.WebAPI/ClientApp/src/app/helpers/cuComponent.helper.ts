import { Inject, Injectable, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import Client from "../clients/client.client";
import BaseDTO from "../models/dto/models/baseDTO.model";
import { ComponentMode } from "../models/enums/componentMode.enum";

// Create-Update component
@Injectable()
export default abstract class CUComponent<TDTO extends BaseDTO> implements OnInit {
    componentModes = ComponentMode;
    componentMode: ComponentMode = ComponentMode.undefined;
    form: FormGroup;
    base: TDTO;

    constructor(
        private readonly _client: Client<TDTO>,
        protected readonly _activatedRoute: ActivatedRoute,
        protected readonly _router: Router,
        @Inject(String) protected readonly _returnUrl: string
    ) { }

    ngOnInit(): void {
        this._initForm();
        this._activatedRoute.params.subscribe(params => this._tryLoadData(params.id));
    }

    protected _tryLoadData(id: number): void {
        this.componentMode = id ? ComponentMode.edit : ComponentMode.create;

        if(id) {
            this._client.get(id).subscribe(entity => {
                this.base = entity;
                this.form.patchValue(entity);
            });
        }
    }

    protected _payloadMapper(entity: TDTO): TDTO {
        return entity;
    }

    protected abstract _initForm(): void;

    onCreateButtonClick(): void {
        this._client.insert(this.form.value).subscribe(() => this._initForm());
    }

    onCreateAndReturnButtonClick(returnUrl: string | null = null): void {
        this._client.insert(this.form.value).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
    }

    onUpdateButtonClick(): void {
        const updatedEntity = {...this._payloadMapper(this.base), ...this.form.value};
        this._client.update(updatedEntity).subscribe();
    }

    onUpdateAndReturnButtonClick(returnUrl: string | null = null): void {
        const updatedEntity = {...this._payloadMapper(this.base), ...this.form.value};
        this._client.update(updatedEntity).subscribe(_ => 
            this._router.navigateByUrl(returnUrl ?? this._returnUrl)
        );
    }
}