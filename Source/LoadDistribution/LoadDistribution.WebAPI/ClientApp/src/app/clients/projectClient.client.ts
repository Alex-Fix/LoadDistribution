import BaseClient from "./baseClient.client";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectDTO from "../models/dto/lecturerDTO.model";

@Injectable({
    providedIn: 'root'
})
export default class ProjectClient extends BaseClient<ProjectDTO> {
    constructor(
        client: HttpClient
    ) {
        super('project', client);
    }
}