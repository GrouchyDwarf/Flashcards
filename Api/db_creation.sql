drop database if exists FlashcardsDb;
go
create database FlashcardsDb;
go
use FlashcardsDb;

create table Decks(
    Id bigint not null identity(1, 1) primary key,
    Name varchar(30) not null
);

alter table Decks
add constraint UC_Decks unique(Name);

create table Flashcards(
    Id bigint not null identity(1, 1) primary key,
    Phrase varchar(50) not null,
    Translation varchar(50) not null, 
    DeckId bigint not null,
    WasMemorized bit not null
);

alter table Flashcards
add constraint UC_Flashcards unique(Phrase);

alter table Flashcards
add constraint FK_Flashcards FOREIGN KEY(DeckId) REFERENCES Decks(Id);