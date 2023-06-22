import { Participant } from "./participant";

export class Barbecue {
    BarbecueIdentifier = "";
    Description = "";
    Participants: Participant[] = [];
    BeginDate = "";
    EndDate = "";
    AdditionalRemarks: string[] = [];
}