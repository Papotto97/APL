package models

type User struct {
	UserId   int    `json:"userId" bson:"userId"`
	Username string `json:"username" bson:"username"`
	Password string `json:"password" bson:"password"`
	Email    string `json:"email" bson:"email"`
	Name     string `json:"name" bson:"name"`
	Surname  string `json:"surname" bson:"surname"`
	Dob      string `json:"dob" bson:"dob"`
}
