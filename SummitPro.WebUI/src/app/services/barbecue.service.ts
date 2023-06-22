import { Injectable } from "@angular/core";
import { Barbecue } from "../models/barbecue";
import { Participant } from "../models/participant";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
    providedIn: 'root'
})
export class BarbecueService {
    private url = "Barbecue";
    private id = "c90cbb30-558e-4064-a23c-ed75a00f1c63";

    constructor(private httpClient: HttpClient) {}

    public getBarbecueFromAPI() : Observable<Barbecue> {
        return this.httpClient.get<Barbecue>(`${environment.apiURL}/${this.url}/${this.id}`);
    }

    public getBarbecues() : Barbecue[] {
        let barbecue = new Barbecue();
        let participant = new Participant();

        participant.Identifier = "identificador qualquer";
        participant.Name = "Yuri Melo";
        participant.Username = "@yuridsm";
        participant.BringDrink = true;
        participant.ContributionValue = 900;
        participant.Items.push("Estou levando água sem gás");
        participant.Items.push("Estou levando água com gás");
        participant.Items.push("Estou levando refrigerante");

        barbecue.BarbecueIdentifier = "identificador qualquer do evento";
        barbecue.Description = "Um evento de Churrasco";
        barbecue.AdditionalRemarks.push("Lembre de fazer o PIX");
        barbecue.BeginDate = "Data de início";
        barbecue.EndDate = "Data de fim";
        barbecue.Participants.push(participant);

        return [barbecue];               
    }
}