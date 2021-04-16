# dotnetApiPkmn
dans appsettings.json changer avec un serveur local que vous avez :
"ConnectionStrings": {
    "pkmnDbConnection" : "server=DESKTOP-TUIIM1P\\MSSQLSERVER01;database=pkmnDb;Trusted_Connection=true"
  }
nom database : pkmnDb

Dans votre SGBD exécuter les commandes : 
use pkmnDb;

table pkmn : 
create table Pkmn (Id int primary key, Name varchar(500), Type varchar(500),  Height float, Weight float, Abilities varchar(500), Moves varchar(500));

table move
create table Move (Id int primary key, Name varchar(500), Damage int,  Accuracy int, Weight float, Type varchar(500));

table ability 
create table Ability (Id int primary key, Name varchar(500), Effect varchar(500))

Les routes de l'api disponibles : 
PKMN :

GET api/pkmn => retourne la liste des pokémons

GET api/pkmn/:id => retourne un pokémon

PUT api/pkmn/:id => prend en body de la requête un Json avec l'id et les attributs du pokémon

DELETE api/pkmn/:id => supprime le pkmn désigné par l'id

POST api/pkmn => enregistre un pokémon en BDD

JSON pkmn =
{
        "id": 16,
        "name": "rattata"
        "type": "electric",
        "height": 3,
        "weight": 35,
        "abilities": "run-away",
        "moves": "cut"
}
le name et le type ne peuvent pas être null ou = ""
le type doit être dans cette liste de type prédéfini {"normal","fighting","flying","poison","ground","rock","bug","ghost","steel","fire","water","grass","electric","psychic","ice","dragon","dark","shadow","fairy"}
Et si le height / weight est 0 alors on le met à 5 par défaut.

Move :

GET api/move => retourne la liste des attaques

GET api/move/:id => retourne une attaque

PUT api/move/:id => prend en body de la requête un Json avec l'id et les attributs de l'attaque

DELETE api/move/:id => supprime le attaque désigné par l'id

POST api/move => enregistre une attaque en BDD

JSON move =
{
	"id": 1,
	"name": "pound",
	"damage": 40,
	"accuracy": 100,
	"type": "normal"
}
le type doit être dans cette liste de type prédéfini {"normal","fighting","flying","poison","ground","rock","bug","ghost","steel","fire","water","grass","electric","psychic","ice","dragon","dark","shadow","fairy"}
Name ne peut pas être null ou ""
Accuracy ne peut pas être > 100 et ne peut pas être Accuracy < 30 et doit être un multiple de 5
damage ne peut pas être < 0 ou > 150 et doit être multiple de 10


ability :

GET api/ability => retourne la liste des habilités

GET api/ability/:id => retourne une habilité

PUT api/ability/:id => prend en body de la requête un Json avec l'id et les attributs de l habilité

DELETE api/ability/:id => supprime l habilité désigné par l'id

POST api/ability => enregistre une habilité en BDD

JSON ability =
{
	"id": 1,
	"name": "stench",
	"effect":"Has no effect in battle."
}
name et effect doivent être renseignés.
