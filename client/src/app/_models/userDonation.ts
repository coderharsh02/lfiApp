import { UserDetail } from "./userDetail";

export interface UserDonation {
    donationId: number;
    noOfMeals: number;
    status: string;
    feedbackByDonor: string;
    feedbackByCollector: string;
    CollectorDetails?: UserDetail;
}