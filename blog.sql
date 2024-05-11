-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 10-Maio-2024 às 00:05
-- Versão do servidor: 10.4.28-MariaDB
-- versão do PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `blog`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `blogpost`
--

CREATE TABLE `blogpost` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Content` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `blogpost`
--

INSERT INTO `blogpost` (`Id`, `Title`, `Content`) VALUES
(138, 'string', 'string'),
(139, 'Ola', 'Eu sou bue bonito'),
(140, 'string', 'string'),
(141, 'string', 'string'),
(142, 'try3', '3'),
(143, 'try4', 's4'),
(144, 'atirei', '1'),
(145, 'o pau', '2'),
(146, 'ao', '3'),
(147, 'gato', 's4'),
(148, 'gato', 's4'),
(149, 'ao', '3'),
(150, 'o pau', '2'),
(151, 'atirei', '1'),
(152, 'try4', 's4'),
(153, 'try3', '3'),
(154, 'string', 'string'),
(155, 'string', 'string'),
(156, 'Ola', 'Eu sou bue bonito'),
(157, 'string', 'string'),
(158, 'gato', 's4'),
(159, 'ao', '3'),
(160, 'o pau', '2'),
(161, 'atirei', '1'),
(162, 'try4', 's4'),
(163, 'try3', '3'),
(164, 'string', 'string'),
(165, 'string', 'string'),
(166, 'Ola', 'Eu sou bue bonito'),
(167, 'string', 'string'),
(168, 'gato', 's4'),
(169, 'ao', '3'),
(170, 'o pau', '2'),
(171, 'atirei', '1'),
(172, 'try4', 's4'),
(173, 'try3', '3'),
(174, 'string', 'string'),
(175, 'string', 'string'),
(176, 'Ola', 'Eu sou bue bonito'),
(177, 'string', 'string'),
(178, 'gato', 's4'),
(179, 'ao', '3'),
(180, 'o pau', '2'),
(181, 'atirei', '1'),
(182, 'try4', 's4'),
(183, 'try3', '3'),
(184, 'string', 'string'),
(185, 'string', 'string'),
(186, 'Ola', 'Eu sou bue bonito'),
(187, 'string', 'string'),
(188, 'gato', 's4'),
(189, 'ao', '3'),
(190, 'o pau', '2'),
(191, 'atirei', '1'),
(192, 'try4', 's4'),
(193, 'try3', '3'),
(194, 'string', 'string'),
(195, 'string', 'string'),
(196, 'Ola', 'Eu sou bue bonito'),
(197, 'string', 'string'),
(198, 'gato', 's4'),
(199, 'ao', '3'),
(200, 'o pau', '2'),
(201, 'atirei', '1'),
(202, 'try4', 's4'),
(203, 'try3', '3'),
(204, 'string', 'string'),
(205, 'string', 'string'),
(206, 'Ola', 'Eu sou bue bonito'),
(207, 'string', 'string'),
(208, 'string', 'string'),
(209, 'Ola', 'Eu sou bue bonito'),
(210, 'string', 'string'),
(211, 'string', 'string'),
(212, 'try3', '3'),
(213, 'try4', 's4'),
(214, 'atirei', '1'),
(215, 'o pau', '2'),
(216, 'ao', '3'),
(217, 'gato', 's4'),
(218, 'gato', 's4'),
(219, 'ao', '3'),
(220, 'o pau', '2'),
(221, 'atirei', '1'),
(222, 'try4', 's4'),
(223, 'try3', '3'),
(224, 'string', 'string'),
(225, 'string', 'string'),
(226, 'Ola', 'Eu sou bue bonito'),
(228, 'string', 'string'),
(229, 'Ola', 'Eu sou bue bonito'),
(230, 'string', 'string'),
(231, 'string', 'string'),
(232, 'try3', '3'),
(233, 'try4', 's4'),
(234, 'atirei', '1'),
(235, 'o pau', '2'),
(237, 'gato', 's4'),
(238, 'gato', 's4'),
(239, 'ao', '3'),
(240, 'o pau', '2'),
(241, 'atirei', '1'),
(242, 'try4', 's4'),
(243, 'try3', '3'),
(244, 'string', 'string'),
(245, 'string', 'string'),
(246, 'Ola', 'Eu sou bue bonito'),
(247, 'string', 'string');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `blogpost`
--
ALTER TABLE `blogpost`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `blogpost`
--
ALTER TABLE `blogpost`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=248;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
