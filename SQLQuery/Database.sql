CREATE DATABASE Forum

go
use Forum
go
create table Usuario(
idUsuario int identity primary key,
nomeUsuario varchar(100) not null,
login varchar(30) not null,
senha varchar(30) not null,
dataCadastro datetime default getDate()
)
go
create table TopicoForum(
idTopico int identity primary key,
titulo varchar(100) not null,
descricao text not null,
dataCadastro datetime default getDate()
)
go
create table Postagem(
idPostagem int identity primary key,
idTopico int foreign key references TopicoForum not null,
idUsuario int foreign key references Usuario not null,
mensagem text not null,
dataPublicacao datetime default getDate()
)