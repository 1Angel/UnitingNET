import type { IUser } from "./IUser";

export interface UserFeedResponse {
    pageNumber: number;
    pageSize:   number;
    totalCount: number;
    data:       IPost[];
}

export interface IPost {
    id:          number;
    description: string;
    user:        IUser;
    community:   Community;
    comments:    any[];
    createdDate: Date;
}

export interface Community {
    id:          number;
    name:        string;
    description: string;
    createdDate: Date;
}


