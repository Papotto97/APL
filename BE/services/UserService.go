package services

import (
	"context"
	"log"
	"strings"
	"unictapl/config"
	"unictapl/models"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
)

func CreateUser(user *models.User) (primitive.ObjectID, string) {
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
		return primitive.ObjectID{}, "Already on DB"
	}

	ris := client.Database("APL").Collection("Users").FindOne(ctx, bson.D{{"username", user.Username}})
	ris.Decode(&r)
	if user.Username == r.Username {
		return primitive.ObjectID{}, "Username already used"
	}
	result, err := client.Database("APL").Collection("Users").InsertOne(ctx, user)
	if err != nil {
		log.Printf("Could not create Movie: %v", err)
		return result.InsertedID.(primitive.ObjectID), "Could not create User"
	}

	return result.InsertedID.(primitive.ObjectID), "User correctly added"

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
