import type { IPost } from "./IUserFeedResponse";

export interface CommunityDetailsResponse {
    pageNumber: number;
    pageSize:   number;
    totalCount: number;
    data:       Posts[];
}

export interface Posts {
    postInfo:         IPost;
    isFavoriteByUser: null;
    userCreated:      boolean;
    totalFavorites:   number;
    totalComments:    number;
    totalBookmarks:   number;
}

