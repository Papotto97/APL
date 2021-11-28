package models

type Favourites struct {
	ImdbId         string `json:"imdbId" bson:"imdbId"`
	PersonalRating string `json:"personalRating" bson:"personalRating"`
	User           User   `json:"user" bson:"user"`
}
