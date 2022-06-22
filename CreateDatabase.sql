

CREATE SCHEMA IF NOT EXISTS sysmanager; DEFAULT CHARACTER SET utf8;

USE sysmanager;

-- -------------------
-- tabela de usuarios
-- -------------------

CREATE TABLE IF NOT EXISTS sysmanager.user
(
`id` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Identificador único',
`userName` varchar(50) NOT NULL COMMENT 'Nome do usuário',
`email` varchar(100) NOT NULL COMMENT 'Email do usuário',
`password` varchar(50) NOT NULL COMMENT 'Senha do usuário',
`active` bit NOT NULL DEFAULT false COMMENT 'Indicador se o usuário está ativo ou inativo',
PRIMARY KEY(`id`)
);

-- -------------------
-- tabela de produtos
-- -------------------

CREATE TABLE IF NOT EXISTS sysmanager.product
(
`id` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Identificador único',
`name` varchar(50) NOT NULL COMMENT 'Descrição do produto',
`productType` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Tipo do produto',
`productCategory` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Categoria do produto',
`productUnity` char(36) NOT NULL DEFAULT 'uuid()' COMMENT 'Unidade de medida do produto',
`costPrice` decimal DEFAULT 0 COMMENT 'Preço do produto',

`password` varchar(50) NOT NULL COMMENT 'Senha do usuário',
`active` bit NOT NULL DEFAULT false COMMENT 'Indicador se o usuário está ativo ou inativo',
PRIMARY KEY(`id`)
);