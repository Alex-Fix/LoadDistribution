import UniversityDTO from "../models/dto/universityDTO.model";
import BaseClient from "./baseClient.client";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export default class UniversityClient extends BaseClient<UniversityDTO> {
    constructor(
        client: HttpClient
    ) {
        super('university', client);
    }
}