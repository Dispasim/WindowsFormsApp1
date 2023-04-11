

drop database fleurs;
create database if not exists fleurs;
use fleurs;

#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: Fleur
#------------------------------------------------------------

CREATE TABLE Fleur(
        Id_Fleur      Int NOT NULL ,
        Nom_Fleur     Varchar (50) NOT NULL ,
        Prix_Fleur    Float NOT NULL ,
        Disponibilite Varchar (50) NOT NULL ,
        Stock         Int NOT NULL
	,CONSTRAINT Fleur_PK PRIMARY KEY (Id_Fleur)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Bouquet
#------------------------------------------------------------

CREATE TABLE Bouquet(
        Id_Bouquet   Int NOT NULL ,
        Nom_Bouquet  Varchar (50) NOT NULL ,
        Prix_Bouquet Float NOT NULL ,
        Categorie    Varchar (50) NOT NULL
	,CONSTRAINT Bouquet_PK PRIMARY KEY (Id_Bouquet)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Compose
#------------------------------------------------------------

CREATE TABLE Compose(
        Id_Bouquet Int NOT NULL ,
        Id_Fleur   Int NOT NULL
	,CONSTRAINT Compose_PK PRIMARY KEY (Id_Bouquet,Id_Fleur)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Commande
#------------------------------------------------------------

CREATE TABLE Commande(
        Numero_Commande   Int NOT NULL ,
        Adresse_Livraison Varchar (50) NOT NULL ,
        Message           Varchar (50) NOT NULL ,
        Date_Commande     date NOT NULL ,
        Code_Etat         Varchar (50) NOT NULL ,
        Courriel          Varchar (50) NOT NULL,
        Id_Bouquet 		  Varchar (50) NOT NULL
	,CONSTRAINT Commande_PK PRIMARY KEY (Numero_Commande)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Client
#------------------------------------------------------------

CREATE TABLE Client(
        Courriel          Varchar (50) NOT NULL ,
        Nom_Client        Varchar (50) NOT NULL ,
        Prenom_Client     Varchar (50) NOT NULL ,
        Telephone         Varchar (50) NOT NULL ,
        Mdp               Varchar (50) NOT NULL ,
        Adresse_Livraison Varchar (50) NOT NULL ,
        Numero            Varchar (50) NOT NULL,
        
	CONSTRAINT Client_PK PRIMARY KEY (Courriel)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Carte_Bancaire
#------------------------------------------------------------

CREATE TABLE Carte_Bancaire(
        Numero          Varchar (50) NOT NULL ,
        Date_Expiration Varchar (50) NOT NULL ,
        Cryptogramme    Varchar (50) NOT NULL ,
        /*Courriel        Varchar (50) NOT NULL,*/
	CONSTRAINT Carte_Bancaire_PK PRIMARY KEY (Numero)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Inclu
#------------------------------------------------------------
/*
CREATE TABLE Inclu(
        Id_Bouquet      Int NOT NULL ,
        Numero_Commande Int NOT NULL
	,CONSTRAINT Inclu_PK PRIMARY KEY (Id_Bouquet,Numero_Commande)
)ENGINE=InnoDB;
*/



ALTER TABLE Compose
	ADD CONSTRAINT Compose_Bouquet0_FK
	FOREIGN KEY (Id_Bouquet)
	REFERENCES Bouquet(Id_Bouquet);

ALTER TABLE Compose
	ADD CONSTRAINT Compose_Fleur1_FK
	FOREIGN KEY (Id_Fleur)
	REFERENCES Fleur(Id_Fleur);
/*
ALTER TABLE Commande
	ADD CONSTRAINT Commande_Client0_FK
	FOREIGN KEY (Courriel)
	REFERENCES Client(Courriel);
    */
/*
ALTER TABLE Client
	ADD CONSTRAINT Client_Carte_Bancaire0_FK
	FOREIGN KEY (Numero)
	REFERENCES Carte_Bancaire(Numero);

ALTER TABLE Client 
	ADD CONSTRAINT Client_Carte_Bancaire0_AK 
	UNIQUE (Numero);
    */
/*
ALTER TABLE Carte_Bancaire
	ADD CONSTRAINT Carte_Bancaire_Client0_FK
	FOREIGN KEY (Courriel)
	REFERENCES Client(Courriel);

ALTER TABLE Carte_Bancaire 
	ADD CONSTRAINT Carte_Bancaire_Client0_AK 
	UNIQUE (Courriel);
*/
/*
ALTER TABLE Inclu
	ADD CONSTRAINT Inclu_Bouquet0_FK
	FOREIGN KEY (Id_Bouquet)
	REFERENCES Bouquet(Id_Bouquet);

ALTER TABLE Inclu
	ADD CONSTRAINT Inclu_Commande1_FK
	FOREIGN KEY (Numero_Commande)
	REFERENCES Commande(Numero_Commande);
    */

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10001,'Gerbera',5.0,"à l'année",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10002,'Ginger',4.0,"à l'année",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10003,'Glaïeul',1.0,"mai à novembre",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10004,'Marguerite',2.25,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10005,'Rose rouge',2.5,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10006,'Rose blanche',5.0,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10007,'Oiseau du paradis',4.0,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10008,'Genet',3.0,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (10009,'Lys',4.0,"à l'annee",100);
insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (100010,'Alstroméria',5.0,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (100011,'Orchidée',3.5,"à l'annee",100);

insert into fleur (Id_Fleur,Nom_Fleur,Prix_Fleur,Disponibilite,Stock)
values (100012,'Verdure',1.0,"à l'annee",100);

insert into bouquet (Id_Bouquet, Nom_Bouquet, Prix_Bouquet, Categorie)
values (20001,'Gros Merci', 45.0, "Toute occasion");

insert into bouquet (Id_Bouquet, Nom_Bouquet, Prix_Bouquet, Categorie)
values (20002,"L'amoureux", 65.0, "St-Valentin");

insert into bouquet (Id_Bouquet, Nom_Bouquet, Prix_Bouquet, Categorie)
values (20003,"L'Exotique", 40.0, "Toute occasion");

insert into bouquet (Id_Bouquet, Nom_Bouquet, Prix_Bouquet, Categorie)
values (20004, 'Maman', 80.0, "Fête des mères");

insert into bouquet (Id_Bouquet, Nom_Bouquet, Prix_Bouquet, Categorie)
values (20005,'Vive la mariée', 120.0, "Mariage");

insert into compose(Id_Bouquet, Id_Fleur)
values (20001,100012);

insert into compose(Id_Bouquet, Id_Fleur)
values (20001,10004);

insert into compose(Id_Bouquet, Id_Fleur)
values (20002,10005);

insert into compose(Id_Bouquet, Id_Fleur)
values (20002,10006);

insert into compose(Id_Bouquet, Id_Fleur)
values (20003,10002);

insert into compose(Id_Bouquet, Id_Fleur)
values (20003,10007);

insert into compose(Id_Bouquet, Id_Fleur)
values (20003,10005);

insert into compose(Id_Bouquet, Id_Fleur)
values (20003,10008);

insert into compose(Id_Bouquet, Id_Fleur)
values (20004,10001);

insert into compose(Id_Bouquet, Id_Fleur)
values (20004,10006);

insert into compose(Id_Bouquet, Id_Fleur)
values (20004,10009);

insert into compose(Id_Bouquet, Id_Fleur)
values (20004,100010);

insert into compose(Id_Bouquet, Id_Fleur)
values (20005,10009);

insert into compose(Id_Bouquet, Id_Fleur)
values (20005,100011);


USE fleurs;

insert into client(Courriel,Nom_Client,Prenom_client,Telephone,Mdp,Adresse_Livraison,Numero)
values("test.test@test.fr","nomtest","prenomtest","0606060606","mdptest","9 rue du test","100000");

INSERT INTO client(Courriel,Nom_Client,Prenom_Client,Telephone,mdp,Adresse_Livraison,Numero) values('test1','test1','test1','test1','test1','test1','test1'); INSERT INTO carte_bancaire(Numero,Date_Expiration,Cryptogramme) values('test1','test1','test1');

INSERT INTO client(Courriel,Nom_Client,Prenom_Client,Telephone,mdp,Adresse_Livraison,Numero) values('test2','test2','test2','test2','test2','test2','test2'); INSERT INTO carte_bancaire(Numero,Date_Expiration,Cryptogramme) values('test2','test2','test2');

INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet) values(8254720, 'chez lui','tg',date('2023-04-11'),'VINV','test2','20002');

INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet) values(8254721, 'chez lui','tg',date('2023-04-11'),'VINV','test2','20002');
insert into carte_bancaire(Numero,Date_Expiration,Cryptogramme)
values("100000","1000-00-00","000");

insert into commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet)
values(1000000,"chez oim","bonjour monde",date("2023-04-11"),"VINV","test1","20001")


