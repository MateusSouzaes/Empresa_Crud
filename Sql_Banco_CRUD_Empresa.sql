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
    nome_fantasia_emp varchar (200) NOT NULL,
    cnpj_emp varchar(14) NOT NULL UNIQUE ,
    insc_emp varchar (20),
    telefone_emp VARCHAR(15) NOT NULL ,
    email_emp varchar(200) NOT NULL ,
    cidade_emp varchar(200) not null,
    fk_id_est int not null,
	cep varchar(9) not null,
    data_emp DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    
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


INSERT INTO Empresa 
(nome_razao_emp, nome_fantasia_emp, cnpj_emp, insc_emp, telefone_emp, email_emp, cidade_emp, fk_id_est, cep)
VALUES
(
    'Tecnologia Avançada Soluções Digitais LTDA', 
    'InovaTech', 
    '11222333000144', 
    '111.222.333.444', 
    '(11) 98765-4321', 
    'contato@inovatech.com.br', 
    'São Paulo', 
    25, -- fk_id_est: 25 = SP
    '01001-000'
),
(
    'Logística Sul Brasil Transportes S.A.', 
    'LogSul', 
    '22333444000155', 
    'ISENTO', 
    '(41) 3322-1100', 
    'operacional@logsul.com', 
    'Curitiba', 
    16, -- fk_id_est: 16 = PR
    '80010-010'
),
(
    'AgroNorte Comércio de Grãos EIRELI', 
    'AgroNorte Rondônia', 
    '33444555000166', 
    NULL, -- Exemplo de Inscrição Estadual nula
    '(69) 99988-7766', 
    'comercial@agronortero.net', 
    'Ji-Paraná', 
    22, -- fk_id_est: 22 = RO
    '76900-087'
),
(
    'Delta Consultoria e Gestão Empresarial LTDA', 
    'Delta Consult', 
    '44555666000177', 
    '87.654.32-1', 
    '(21) 2555-8998', 
    'atendimento@deltaconsult.com.br', 
    'Rio de Janeiro', 
    19, -- fk_id_est: 19 = RJ
    '20040-001'
),
(
    'Sabor Mineiro Alimentos Processados LTDA', 
    'Sabor de Minas', 
    '55666777000188', 
    '062.123456.00-89', 
    '(31) 3224-5000', 
    'vendas@sabordeminas.ind.br', 
    'Belo Horizonte', 
    13, -- fk_id_est: 13 = MG
    '30110-001'
);