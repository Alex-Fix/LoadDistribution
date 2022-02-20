import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectDTO from "../models/dto/projectDTO";
import CollectionClient from './collectionClient.client';

@Injectable({
    providedIn: 'root'
})
export default class ProjectClient extends CollectionClient<ProjectDTO> {
    constructor(
        client: HttpClient
    ) {
        super('project', client);
    }
}