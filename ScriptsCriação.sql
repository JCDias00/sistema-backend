--Criar Banco de Dados 

CREATE DATABASE programacao_do_zero;

-- usar o banco de dados

USE programacao_do_zero;

-- Criar tabela usuario

CREATE TABLE usuario (

id INT NOT NULL AUTO_INCREMENT,
nome VARCHAR(15) NOT NULL,
sobrenome VARCHAR(50) NOT NULL,
telefone VARCHAR(15) NOT NULL,
email VARCHAR(50) NOT NULL,
genero VARCHAR(20) NOT NULL,
senha VARCHAR(30) NOT NULL,
PRIMARY KEY (id)

);

-- criar tabela endereço 

CREATE table endereço (

id INT NOT NULL auto_increment,
rua varchar(250) not null,
numero varchar(30) not null,
bairro varchar(150) not null,
cidade varchar(250) not null,
complemento varchar(150) null,
cep varchar(9) not null,
estado varchar(2) not null,
primary key (id)

);

-- alterar tabela endereço

ALTER table endereço ADD usuario_id int not null; 


-- adicionar chave estrangeira

ALTER table endereço add constraint FK_usuario foreign key (usuario_id) references usuario(id);

-- inserir usuario

insert into usuario(nome,
 sobrenome,
 telefone, 
 email,
 genero, 
 senha) value ('renato', 
 'Gava', 
 '(11) 99532-4543',
 'renatogava2@live.com', 
 'masculino', 
 '1234')


 insert into programacao_do_zero.usuario(nome,
 sobrenome,
 email, 
 telefone,
 genero, 
 senha) value ('Gustavo', 
 'Augusto', 
 'gustavo@gmail.com',
 '62982405269', 
 'masculino', 
 'teste1234')

 -- selecionar usuario

 select * from programacao_do_zero.usuario;

 -- selecionar um usuario especifico

 select * from programacao_do_zero.usuario where email = "gustavo@gmail.com";

 -- alterar usuario


 update programacao_do_zero.usuario set email = "gustavvvo@gmail.com" where id=3;

 -- excluir usuario 

delete from programacao_do_zero.usuario where id = 3;

delete from programacao_do_zero.usuario where  id in (1,2,3,4,5);

delete from programacao_do_zero.usuario where id > 2;



 