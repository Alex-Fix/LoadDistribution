import { merge, Observable } from "rxjs";
import Client from "../clients/client.client";
import IDTO from "../models/dto/interfaces/iDTO.interface";
import IPayloadMapper from "../models/helpers/interfaces/iPayloadMapper.interface";
import OperationManager from "./operationManager.helper";

export default class SynchronizationManager<TDTO extends IDTO> {
    constructor(
        private readonly _client: Client<TDTO>,
        private readonly _payloadMapper: IPayloadMapper
    ) {
    }

    synchronize(operationManager: OperationManager<TDTO>): Observable<void> {
        const updateEntities = operationManager.updated.map(o => { return {...this._payloadMapper(o.dto), ...o.form.value}; });
        const createEntities = operationManager.created.map(o => { return {...this._payloadMapper(null), ...o.form.value}; });
        const deleteEntities = operationManager.deleted.map(o => o.id);

        const observables: Observable<unknown>[] = [];

        if (updateEntities.length) {
            observables.push(this._client.bulkUpdate(updateEntities));
        }

        if (createEntities.length) {
            observables.push(this._client.bulkInsert(createEntities));
        }

        if(deleteEntities.length) {
            deleteEntities.forEach(e => observables.push(this._client.delete(e)));
        }
        
        return merge(...observables) as Observable<void>;
    }
}