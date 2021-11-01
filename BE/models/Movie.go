package models

type Movie struct {
	ImdbId string  `json:"imdbId" bson:"imdbId"`
	Name   string  `json:"name" bson:"name"`
	Rating float64 `json:"rating" bson:"rating"`
	//Genres string  `json:"genres" bson:"genres"`
	Genres    []string `json:"genres" bson:"genres"`
	Date      string   `json:"date" bson:"date"`
	Timestamp string   `json:"timestamp" bson:"timestamp"`
}
