create database DbVacinacaoBovina

go

use DbVacinacaoBovina

go 

create table Especie(
	IdEspecie int not null primary key identity(1,1),
	Nome varchar(30) not null
)

go

create table TipoDeEntrada(
	idTipoDeEntrada int primary key identity(1,1) not null,
	Nome varchar(20)
)

go

create table FinalidadeDeVenda(
	IdFinalidadeDeVenda int not null primary key identity(1,1),
	Nome varchar(30) not null
)

go

create table Vacina(
	IdVacina int not null primary key identity(1,1),
	Nome varchar(50) not null,
	Doenca varchar(50) not null,
	Tipo varchar(10) not null,
	Marca varchar(30) not null
)

go

create table Municipio(
	IdMunicipio int primary key identity(1,1) not null,
	Nome varchar(50) not null,
	Estado varchar(2) not null,
)

go

create table Endereco(
	IdEndereco int primary key identity(1,1) not null,
	Rua varchar(150) not null,
	Numero varchar(20) not null,
	IdMunicipio int not null references Municipio(IdMunicipio)
)

go

create table Produtor(
	IdProdutor int primary key identity(1,1) not null,
	Nome varchar(50) not null,
	CPF varchar(11) not null,
	IdEndereco int not null references Endereco(IdEndereco)
)

go

create table Propriedade(
	IdPropriedade int primary key identity(1,1) not null,
	InscricaoEstadual varchar(10) not null,
	Nome varchar(50) not null,
	IdEndereco int not null references Endereco(IdEndereco),
	IdProdutor int not null references Produtor(IdProdutor)
)

go

create table Animal(
	IdAnimal int primary key identity(1,1),
	QuantidadeTotal int not null,
	QuantidadeVacinada int not null,
	IdEspecie int not null references Especie(IdEspecie),
	IdPropriedade int not null references Propriedade(IdPropriedade),
	IdTipoDeEntrada int not null references TipoDeEntrada(IdTipoDeEntrada),
	DataDeEntrada datetime not null,
	Ativo bit not null default 1
)

go

create table Rebanho(
	idRebanho int primary key identity(1,1) not null,
	QuantidadeTotal int not null,
	QuantidadeVacinadaAftosa int not null,
	QuantidadeVacinadaBrucelose int not null,
	idEspecie int not null references Especie(idEspecie),
	idPropriedade int not null references Propriedade(idPropriedade)
)

go

create table Venda(
	IdVenda int not null primary key identity(1,1),
	Quantidade int not null,
	IdOrigem int not null references Propriedade(IdPropriedade),
	IdDestino int not null references Propriedade(IdPropriedade),
	IdRebanho int not null references Rebanho(idRebanho),
	IdFinalidadeDeVenda int not null references FinalidadeDeVenda(IdFinalidadeDeVenda),
	DataDeVenda datetime not null,
	Ativo bit not null default 1
)

go

create table RegistroVacinacao(
	IdRegistroVacinacao int not null primary key identity(1,1),	
	IdVacina int not null references Vacina(IdVacina),
	IdRebanho int not null references Rebanho(IdRebanho),
	Quantidade int not null,
	DataDaVacina date not null,
	DataDeCadastro datetime not null,
	Ativo bit not null default 1
)
