package services

import (
	"context"
	"log"
	"strings"
	"unictapl/config"
	"unictapl/models"

	"go.mongodb.org/mongo-driver/bson"
)

func CreateUser(user *models.User) models.ResponseDTO {
	var s models.User
	var r models.User

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)
	if len(user.Username) == 0 {
		user.Username = RandomUsername(user.Email)
	}

	res := client.Database("APL").Collection("Users").FindOne(ctx, bson.D{{"email", user.Email}})
	res.Decode(&s)
	if user.Email == s.Email {
		return models.ResponseDTO{"Email already used", 400}
	}

	ris := client.Database("APL").Collection("Users").FindOne(ctx, bson.D{{"username", user.Username}})
	ris.Decode(&r)
	if user.Username == r.Username {
		return models.ResponseDTO{"Username already used", 400}
	}

	_, err := client.Database("APL").Collection("Users").InsertOne(ctx, user)
	if err != nil {
		log.Printf("Could not create User: %v", err)
		return models.ResponseDTO{"Could not create User", 500}
		// return result.InsertedID.(primitive.ObjectID), "Could not create User"
	}
	return models.ResponseDTO{"User correctly added", 200}
	// return result.InsertedID.(primitive.ObjectID), "User correctly added"

}
func FindUserByUsername(username string) (user models.User) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("APL").Collection("Users").FindOne(ctx, bson.D{{"username", username}}).Decode(&user)
	if err != nil {
		return models.User{}
	}
	return user
}
func FindUserByUsernameAndPassword(username string, password string) (user models.User) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("APL").Collection("Users").FindOne(ctx, bson.D{{"username", username}, {"password", password}}).Decode(&user)
	if err != nil {
		return models.User{}
	}
	return user
}
func FindUserByEmail(email string) (user models.User) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("APL").Collection("Users").FindOne(ctx, bson.D{{"email", email}}).Decode(&user)
	if err != nil {
		return models.User{}
	}
	return user
}

func FindAllUsers() (users []models.User) {
	var results []models.User

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	result, err := client.Database("APL").Collection("Users").Find(ctx, bson.D{})
	if err != nil {
		log.Fatal(err)
		return results
	}
	for result.Next(context.TODO()) {
		//Create a value into which the single document can be decoded
		var user models.User
		err := result.Decode(&user)
		if err != nil {
			log.Fatal(err)
		}

		results = append(results, user)

	}
	return results
}

func RandomUsername(email string) string {
	return strings.Split(email, "@")[0]
}
