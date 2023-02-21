import { UserDetail } from "./userDetail";

export interface UserCollection {
    donationId: number;
    noOfMeals: number;
    status: string;
    feedbackByDonor: string;
    feedbackByCollector: string;
    DonorDetails?: UserDetail;
}