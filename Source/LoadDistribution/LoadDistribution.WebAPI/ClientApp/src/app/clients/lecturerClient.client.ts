import LecturerDTO from "../models/dto/lecturerDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class LecturerClient extends ProjectRelatedCollectionClient<LecturerDTO> {
    constructor(
        client: HttpClient
    ) {
        super('lecturer', client);
    }
}