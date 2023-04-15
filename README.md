drop database fleurs;
create database if not exists fleurs;
use fleurs;

#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: fleur
#------------------------------------------------------------

CREATE TABLE fleur(
        Id_Fleur      Int NOT NULL ,
        Nom_Fleur     Varchar (50) NOT NULL ,
        Prix_Fleur    Float NOT NULL ,
        Disponibilite Varchar (50) NOT NULL ,
        Stock         Int NOT NULL
	,CONSTRAINT fleur_PK PRIMARY KEY (Id_Fleur)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: bouquet
#------------------------------------------------------------

CREATE TABLE bouquet(
        Id_Bouquet   Int NOT NULL ,
        Nom_Bouquet  Varchar (50) NOT NULL ,
        Prix_Bouquet Float NOT NULL ,
        Categorie    Varchar (50) NOT NULL
	,CONSTRAINT bouquet_PK PRIMARY KEY (Id_Bouquet)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Accessoire
#------------------------------------------------------------

CREATE TABLE Accessoire(
        Vase  Bool NOT NULL ,
        Boite Bool NOT NULL ,
        Ruban Bool NOT NULL
	,CONSTRAINT Accessoire_PK PRIMARY KEY (Vase,Boite,Ruban)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: client
#------------------------------------------------------------

CREATE TABLE client(
        Courriel            Varchar (50) NOT NULL ,
        Nom_Client          Varchar (50) NOT NULL ,
        Prenom_Client       Varchar (50) NOT NULL ,
        Telephone           Varchar (50) NOT NULL ,
        Mdp                 Varchar (50) NOT NULL ,
        Adresse_Facturation Varchar (50) NOT NULL ,
        Numero_Carte        Varchar (50) NOT NULL ,
        Date_Expiration     Varchar (50) NOT NULL ,
        Cryptogramme        Varchar (50) NOT NULL
	,CONSTRAINT client_PK PRIMARY KEY (Courriel)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: magasin
#------------------------------------------------------------

CREATE TABLE magasin(
        Id_Magasin      Int NOT NULL ,
        Adresse_magasin Varchar (50) NOT NULL
	,CONSTRAINT magasin_PK PRIMARY KEY (Id_Magasin)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: commande
#------------------------------------------------------------

CREATE TABLE commande(
        Numero_Commande   Int NOT NULL ,
        Adresse_Livraison Varchar (50) NOT NULL ,
        Message           Varchar (50) NOT NULL ,
        date_Commande     Date NOT NULL ,
        Code_Etat         Varchar (50) NOT NULL ,
        Id_Bouquet        Int ,
        Courriel          Varchar (50) NOT NULL ,
        Id_Magasin        Int NOT NULL,
        Commande_Perso	  Bool NOT NULL DEFAULT False 
        
	,CONSTRAINT commande_PK PRIMARY KEY (Numero_Commande)
/*
	,CONSTRAINT commande_bouquet_FK FOREIGN KEY (Id_Bouquet) REFERENCES bouquet(Id_Bouquet)
	,CONSTRAINT commande_client0_FK FOREIGN KEY (Courriel) REFERENCES client(Courriel)
	,CONSTRAINT commande_magasin1_FK FOREIGN KEY (Id_Magasin) REFERENCES magasin(Id_Magasin)
    */
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: compose
#------------------------------------------------------------

CREATE TABLE compose(
        Id_Bouquet Int NOT NULL ,
        Id_Fleur   Int NOT NULL ,
        Nombre     Int NOT NULL
	,CONSTRAINT compose_PK PRIMARY KEY (Id_Bouquet,Id_Fleur)

	,CONSTRAINT compose_bouquet_FK FOREIGN KEY (Id_Bouquet) REFERENCES bouquet(Id_Bouquet)
	,CONSTRAINT compose_fleur0_FK FOREIGN KEY (Id_Fleur) REFERENCES fleur(Id_Fleur)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: commande_perso
#------------------------------------------------------------

CREATE TABLE commande_perso(
        Numero_Commande Int NOT NULL ,
        Id_Fleur        Int NOT NULL ,
        Nombre          Int NOT NULL
        
	,CONSTRAINT commande_perso_PK PRIMARY KEY (Numero_Commande,Id_Fleur)

	,CONSTRAINT commande_perso_commande_FK FOREIGN KEY (Numero_Commande) REFERENCES commande(Numero_Commande)
	,CONSTRAINT commande_perso_fleur0_FK FOREIGN KEY (Id_Fleur) REFERENCES fleur(Id_Fleur)
    
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: accessoire_commande
#------------------------------------------------------------

CREATE TABLE accessoire_commande(
        Vase            Bool NOT NULL ,
        Boite           Bool NOT NULL ,
        Ruban           Bool NOT NULL ,
        Numero_Commande Int NOT NULL
	,CONSTRAINT accessoire_commande_PK PRIMARY KEY (Vase,Boite,Ruban,Numero_Commande)

	,CONSTRAINT accessoire_commande_Accessoire_FK FOREIGN KEY (Vase,Boite,Ruban) REFERENCES Accessoire(Vase,Boite,Ruban)
	,CONSTRAINT accessoire_commande_commande0_FK FOREIGN KEY (Numero_Commande) REFERENCES commande(Numero_Commande)
)ENGINE=InnoDB;

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

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20001,100012,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20001,10004,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20002,10005,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20002,10006,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20003,10002,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20003,10007,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20003,10005,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20003,10008,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20004,10001,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20004,10006,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20004,10009,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20004,100010,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20005,10009,10);

insert into compose(Id_Bouquet, Id_Fleur,Nombre)
values (20005,100011,10);


USE fleurs;

insert into client(Courriel,Nom_Client,Prenom_client,Telephone,Mdp,Adresse_Facturation,Numero_carte,Date_Expiration,Cryptogramme)
values("test.test@test.fr","nomtest","prenomtest","0606060606","mdptest","9 rue du test","100000","1000-00-00","000");

INSERT INTO client(Courriel,Nom_Client,Prenom_Client,Telephone,mdp,Adresse_Facturation,Numero_Carte,Date_Expiration,Cryptogramme) values('test1','test1','test1','test1','test1','test1','test1','test1','test1'); 

INSERT INTO client(Courriel,Nom_Client,Prenom_Client,Telephone,mdp,Adresse_Facturation,Numero_Carte,Date_Expiration,Cryptogramme) values('test2','test2','test2','test2','test2','test2','test2','test2','test2'); 

INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet,Id_Magasin) values(8254720, 'chez lui','tg',date('2023-04-11'),'VINV','test2',20002,30001);

INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet,Id_Magasin) values(8254721, 'chez lui','tg',date('2023-04-11'),'VINV','test2',20002,30001);

INSERT INTO  magasin(Id_magasin, Adresse_magasin) VALUES(30001,"quelque part");

INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet,id_Magasin)
values(1000000,"chez oim","bonjour monde",date("2023-04-11"),"VINV","test1",20001,30001)
