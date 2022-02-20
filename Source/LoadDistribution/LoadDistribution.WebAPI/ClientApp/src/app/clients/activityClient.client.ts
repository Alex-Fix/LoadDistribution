import ActivityDTO from "../models/dto/activityDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class ActivityClient extends ProjectRelatedCollectionClient<ActivityDTO> {
    constructor(
        client: HttpClient 
    ) {
        super('activity', client);
    }
}