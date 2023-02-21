import { UserCollection } from "./userCollection";
import { UserDetail } from "./userDetail";
import { UserDonation } from "./userDonation";

export interface FullUserDetail {
    user: UserDetail,
    donations: UserDonation[],
    collections: UserCollection[]
}