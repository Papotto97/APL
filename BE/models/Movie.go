package models

type Movie struct {
	ImdbId string  `json:"imdbId" bson:"imdbId"`
	Name   string  `json:"name" bson:"name"`
	Rating float64 `json:"rating" bson:"rating"`
	Genres string  `json:"genres" bson:"genres"`
	//Genres list.List `json:"genres" bson:"genres"`
}
