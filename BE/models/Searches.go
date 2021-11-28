package models

type Searches struct {
	SearchType   string `json:"searchType" bson:"searchType"`
	Expression   string `json:"expression" bson:"expression"`
	ImdbId       string `json:"imdbId" bson:"imdbId"`
	MovieTitle   string `json:"movieTitle" bson:"movieTitle"`
	ErrorMessage string `json:"errorMessage" bson:"errorMessage"`
	User         User   `json:"user" bson:"user"`
}
