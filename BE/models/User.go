package models

type User struct {
	Username string `json:"username" bson:"username"`
	Password string `json:"password" bson:"password"`
	Email    string `json:"email" bson:"email"`
	Name     string `json:"name" bson:"name"`
	Surname  string `json:"surname" bson:"surname"`
}
