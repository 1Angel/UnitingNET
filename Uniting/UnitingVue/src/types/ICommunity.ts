import type { IUser } from "./IUser";

export interface ICommunity {
    id:              number;
    name:            string;
    description:     string;
    isUserFollowing: boolean;
    totalMembers:    number;
    posts:           any[];
    user:            IUser;
    createdDate:     Date;
}
