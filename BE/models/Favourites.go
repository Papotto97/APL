package models

type Favourites struct {
	ImdbId         string  `json:"imdbId" bson:"imdbId"`
	PersonalRating float64 `json:"personalRating" bson:"personalRating"`
	User           User    `json:"user" bson:"user"`
}
