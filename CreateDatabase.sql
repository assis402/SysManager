USE freedb_sysmanagerdb;

-- ---------------------------
-- tabela de usuários
-- ---------------------------
CREATE TABLE IF NOT EXISTS `user`
(
`id` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Identificador unico do registro',
`userName` varchar(50) NOT NULL COMMENT 'nome do usuário',
`email` varchar(100) NOT NULL COMMENT 'email do usuário',
`password` varchar(50) NOT NULL COMMENT 'senha do usuário',
`active` bit NOT NULL DEFAULT false COMMENT 'indicador se o usuário esta ativo ou inativo',
PRIMARY KEY(`id`)
);

-- ---------------------------
-- tabela de produtos
-- ---------------------------
CREATE TABLE IF NOT EXISTS product
(
`id` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Identificador unico do registro',
`name` varchar(50) NOT NULL COMMENT 'nome/Descrição do produto',
`productType` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'tipo do produto',
`productCategory` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'categoria do produto',
`productUnity` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'unidade de medida do produto',
`costPrice` decimal DEFAULT 0  COMMENT 'preço de custo do produto',
`percentage` decimal DEFAULT 0  COMMENT 'percentual de venda do produto',
`price` decimal DEFAULT 0  COMMENT 'preço final do produto',
`active` bit NOT NULL DEFAULT false COMMENT 'indicador se o usuário esta ativo ou inativo',
PRIMARY KEY(`id`)
);


-- -----------------------------------------------------
-- Table `sysManager`.`productType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS productType (
  `id` CHAR(36) not null default 'uuid()' comment 'Identificador do registro',
  `name` varchar(100) not null comment 'Nome do Tipo de produto',
  `active` bit NOT NULL default false comment 'Ativo ou inativo',
  `createdDate` datetime not null default NOW() comment 'data de criação do registro',
  `updatedDate` datetime null comment 'data de atualização do registro',
  PRIMARY KEY (`id`)
  );

-- -----------------------------------------------------
-- Table `sysManager`.`unity`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS unity (
  `id` CHAR(36) not null default 'uuid()' comment 'Identificador do registro',
  `name` varchar(100) not null comment 'Nome do Unidade de produto',
  `active` bit NOT NULL default false comment 'Ativo ou inativo',
  `createdDate` datetime not null default NOW() comment 'data de criação do registro',
  `updatedDate` datetime null  comment 'data de atualização do registro',
  PRIMARY KEY (`id`)
  );

-- -----------------------------------------------------
-- Table `sysManager`.`category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS category (
  `id` CHAR(36) not null default 'uuid()' comment 'Identificador do registro',
  `name` varchar(100) not null comment 'Nome do categoria de produto',
  `parentId` varchar(50)  null comment 'Identificador do Tipo de produto pai',  
  `active` bit NOT NULL default false comment 'Ativo ou inativo',
  `createdDate` datetime not null default NOW() comment 'data de criação do registro',
  `updatedDate` datetime null comment 'data de atualização do registro',
  PRIMARY KEY (`id`)
  )