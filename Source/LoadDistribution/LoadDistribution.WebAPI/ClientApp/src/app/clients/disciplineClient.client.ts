import DisciplineDTO from "../models/dto/disciplineDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class DisciplineClient extends ProjectRelatedCollectionClient<DisciplineDTO> {
    constructor(
        client: HttpClient
    ) {
        super('discipline', client);
    }
}