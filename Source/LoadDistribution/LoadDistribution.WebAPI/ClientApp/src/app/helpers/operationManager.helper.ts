import { AbstractControl, FormArray, FormGroup } from "@angular/forms";
import { Observable, Subject, Subscription } from "rxjs";
import IDTO from "../models/dto/interfaces/iDTO.interface";
import IFormInitializer from "../models/helpers/interfaces/iFormInitializer.interface";
import CreateOperation from "../models/helpers/models/createOperation.model";
import DeleteOperation from "../models/helpers/models/deleteOperation.model";
import Operation from "../models/helpers/models/operation.model";
import UndefinedOperation from "../models/helpers/models/undefinedOperation.model";
import UpdateOperation from "../models/helpers/models/updateOperation.model";

export default class OperationManager<TDTO extends IDTO> {
    readonly _operations: Operation[] = [];
    readonly _controls: Subject<FormGroup[]> = new Subject<FormGroup[]>();

    readonly formArray: FormArray = new FormArray([]);

    constructor(
        private readonly _initializer: IFormInitializer<TDTO>
    ) {
    }

    get controls(): Observable<FormGroup[]> {
        return this._controls;
    }

    get updated(): UpdateOperation<TDTO>[] {
        return this._operations
            .filter(o => o instanceof UpdateOperation)
            .map(o => o as UpdateOperation<TDTO>);
    }

    get created(): CreateOperation[] {
        return this._operations
            .filter(o => o instanceof CreateOperation)
            .map(o => o as CreateOperation);
    }

    get deleted(): DeleteOperation[] {
        return this._operations
            .filter(o => o instanceof DeleteOperation)
            .map(o => o as DeleteOperation);
    }

    add(dto: TDTO): void {
        const form: FormGroup = this._initializer(dto);
        const operation: UndefinedOperation<TDTO> = new UndefinedOperation<TDTO>(dto, form);

        this.formArray.push(form);
        this._operations.push(operation);
        this._updateControls();

        const subscription: Subscription = form.valueChanges.subscribe(_ => {
            subscription.unsubscribe();

            const operationIndex: number = this._operations.findIndex(o => o == operation);
            let newOperation: UpdateOperation<TDTO> = operation.toUpdateOperation();
            this._operations[operationIndex] = newOperation;
        });
    }

    addRange(dtos: TDTO[]): void {
        dtos.forEach(dto => this.add(dto));
    }

    create(): void {
        let form: FormGroup = this._initializer(null);
        this.formArray.push(form);
        this._operations.push(new CreateOperation(form));
        this._updateControls();
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

        const formIndex = this.formArray.controls.findIndex(f => f == form);
        if(formIndex != -1) {
            this.formArray.removeAt(formIndex);
            this._updateControls();
        }
    }

    clear(): void {
        this._operations.splice(0, this._operations.length);
        this.formArray.clear();
        this._updateControls();
    }

    private _updateControls(): void {
        this._controls.next(this.formArray.controls as FormGroup[]);
    }
}