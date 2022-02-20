import UniversityDTO from "../models/dto/universityDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class UniversityClient extends ProjectRelatedCollectionClient<UniversityDTO> {
    constructor(
        client: HttpClient
    ) {
        super('university', client);
    }
}