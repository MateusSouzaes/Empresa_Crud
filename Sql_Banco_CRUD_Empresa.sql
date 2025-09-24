create database crud_empresa;
use crud_empresa;

create table Estado(
	id_est int primary key auto_increment,
    uf_est  varchar(2) not null,
    nome_est varchar(20) not null
);

create table Empresa(
	id_emp int primary key auto_increment,
    nome_razao_emp varchar(200) NOT NULL ,
    cnpj_emp varchar(14) NOT NULL UNIQUE ,
    insc_emp varchar (20),
    telefone_emp VARCHAR(15) NOT NULL ,
    email_emp varchar(200) NOT NULL ,
    cidade_emp varchar(200) not null,
    fk_id_est int not null,
	cep varchar(9) not null,
    data_emp datetime not null,
    
    FOREIGN KEY (fk_id_est) REFERENCES Estado(id_est)
);


INSERT INTO Estado (uf_est, nome_est) VALUES
('AC', 'Acre'),
('AL', 'Alagoas'),
('AP', 'Amapá'),
('AM', 'Amazonas'),
('BA', 'Bahia'),
('CE', 'Ceará'),
('DF', 'Distrito Federal'),
('ES', 'Espírito Santo'),
('GO', 'Goiás'),
('MA', 'Maranhão'),
('MT', 'Mato Grosso'),
('MS', 'Mato Grosso do Sul'),
('MG', 'Minas Gerais'),
('PA', 'Pará'),
('PB', 'Paraíba'),
('PR', 'Paraná'),
('PE', 'Pernambuco'),
('PI', 'Piauí'),
('RJ', 'Rio de Janeiro'),
('RN', 'Rio Grande do Norte'),
('RS', 'Rio Grande do Sul'),
('RO', 'Rondônia'),
('RR', 'Roraima'),
('SC', 'Santa Catarina'),
('SP', 'São Paulo'),
('SE', 'Sergipe'),
('TO', 'Tocantins');

    