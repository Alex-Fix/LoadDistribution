import { AbstractControl, FormGroup, FormArray } from "@angular/forms";
import { BehaviorSubject, concat, Observable, Subscription } from "rxjs";
import { defaultIfEmpty } from "rxjs/operators";
import Client from "../clients/client.client";
import IDTO from "../models/dto/interfaces/iDTO.interface";
import IFormInitializer from "../models/helpers/interfaces/iFormInitializer.interface";
import IPayloadMapper from "../models/helpers/interfaces/iPayloadMapper.interface";
import CreateOperation from "../models/helpers/models/createOperation.model";
import DeleteOperation from "../models/helpers/models/deleteOperation.model";
import Operation from "../models/helpers/models/operation.model";
import UndefinedOperation from "../models/helpers/models/undefinedOperation.model";
import UpdateOperation from "../models/helpers/models/updateOperation.model";

export default class OperationManager<TDTO extends IDTO> {
    private readonly _operations: Operation[] = [];
    private readonly _formArray: FormArray = new FormArray([]);
    private readonly _controls$: BehaviorSubject<FormGroup[]> = new BehaviorSubject<FormGroup[]>(this.controls);

    constructor(
        private readonly _client: Client<TDTO>,
        private readonly _initializer: IFormInitializer<TDTO>
    ) {
        this._formArray.valueChanges.subscribe(() => this._controls$.next(this.controls));
    }

    get controls$(): Observable<FormGroup[]> {
        return this._controls$;
    }

    get controls(): FormGroup[] {
        return this._formArray.controls as FormGroup[];
    }

    get formArray(): FormArray {
        return this._formArray;
    }

    add(dto: TDTO): void {
        const form: FormGroup = this._initializer(dto);
        const operation: UndefinedOperation<TDTO> = new UndefinedOperation<TDTO>(dto, form);

        this._formArray.push(form);
        this._operations.push(operation);
        
        const subscription: Subscription = form.valueChanges.subscribe(() => {
            subscription.unsubscribe();

            const operationIndex: number = this._operations.findIndex(o => o == operation);
            if (operationIndex != -1) {
                let newOperation: UpdateOperation<TDTO> = operation.toUpdateOperation();
                this._operations[operationIndex] = newOperation;
            }
        });
    }

    addRange(dtos: TDTO[]): void {
        dtos.forEach(dto => this.add(dto));
    }

    create(): void {
        let form: FormGroup = this._initializer(null);

        this._formArray.push(form);
        this._operations.push(new CreateOperation(form));
    }

    delete(form: AbstractControl | FormGroup): void {
        const operationIndex = this._operations.findIndex(o => o.form == form);
        if(operationIndex != -1) {
            const operation: Operation = this._operations[operationIndex];
            
            if(operation instanceof CreateOperation) {

                this._operations.splice(operationIndex, 1);

            } else if (operation instanceof UndefinedOperation) {

                this._operations[operationIndex] = (operation as UndefinedOperation<TDTO>).toDeleteOperation();

            } else if (operation instanceof UpdateOperation) {

                this._operations[operationIndex] = (operation as UpdateOperation<TDTO>).toDeleteOperation();

            }
        }

        const formIndex = this._formArray.controls.findIndex(f => f == form);
        if(formIndex != -1) {
            this._formArray.removeAt(formIndex);
        }
    }

    synchronize(mapper: IPayloadMapper<TDTO>): Observable<void> {
        const observables: Observable<unknown>[] = [];

        const deleted = this._deleted.map(o => o.id);
        if (deleted.length) 
        {
            observables.push(...deleted.map(d => this._client.delete(d)));
        }

        const created = this._created.map(o => mapper(null, o.form));
        if (created.length) {
            observables.push(this._client.bulkInsert(created));
        }

        const updated = this._updated.map(o => mapper(o.dto, o.form));
        if (updated.length) {
            observables.push(this._client.bulkUpdate(updated));
        }

        return concat(...observables)
            .pipe(
                defaultIfEmpty(null as any) // this is workaround!!! I hope I can improve it in the future
            ) as Observable<void>;
    }

    clear(): void {
        this._operations.splice(0, this._operations.length);
        this._formArray.clear();
    }

    private get _updated(): UpdateOperation<TDTO>[] {
        return this._operations
            .filter(o => o instanceof UpdateOperation)
            .map(o => o as UpdateOperation<TDTO>);
    }

    private get _created(): CreateOperation[] {
        return this._operations
            .filter(o => o instanceof CreateOperation)
            .map(o => o as CreateOperation);
    }

    private get _deleted(): DeleteOperation[] {
        return this._operations
            .filter(o => o instanceof DeleteOperation)
            .map(o => o as DeleteOperation);
    }
}