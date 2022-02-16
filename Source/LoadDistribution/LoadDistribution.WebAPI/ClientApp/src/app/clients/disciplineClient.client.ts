import DisciplineDTO from "../models/dto/disciplineDTO.model";
import BaseClient from "./baseClient.client";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export default class DisciplineClient extends BaseClient<DisciplineDTO> {
    constructor(
        client: HttpClient
    ) {
        super('discipline', client);
    }
}