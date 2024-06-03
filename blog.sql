-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 03-Jun-2024 às 02:56
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
(247, 'string', 'string'),
(248, 'string', 'string'),
(249, 'string', 'string'),
(250, 'string', 'string'),
(251, 'string', 'string'),
(252, 'string', 'string'),
(253, 'string', 'string'),
(254, 'string', 'string'),
(255, 'string', 'string'),
(256, 'string', 'string'),
(257, 'string', 'string'),
(258, 'string', 'string'),
(259, 'string', 'string'),
(260, 'Ola', 'Eu sou bue bonito'),
(261, 'string', 'string'),
(262, 'string', 'string'),
(263, 'try3', '3'),
(264, 'try4', 's4'),
(265, 'atirei', '1'),
(266, 'o pau', '2'),
(267, 'ao', '3'),
(268, 'gato', 's4'),
(269, 'gato', 's4'),
(270, 'o pau', '2'),
(271, 'atirei', '1'),
(272, 'try4', 's4'),
(273, 'try3', '3'),
(274, 'string', 'string'),
(275, 'string', 'string'),
(276, 'Ola', 'Eu sou bue bonito'),
(277, 'string', 'string'),
(278, 'Ola', 'Eu sou bue bonito'),
(279, 'string', 'string'),
(280, 'string', 'string'),
(281, 'try3', '3'),
(282, 'try4', 's4'),
(283, 'atirei', '1'),
(284, 'o pau', '2'),
(285, 'ao', '3'),
(286, 'gato', 's4'),
(287, 'gato', 's4'),
(288, 'ao', '3'),
(289, 'o pau', '2'),
(290, 'atirei', '1'),
(291, 'try4', 's4'),
(292, 'try3', '3'),
(293, 'string', 'string'),
(294, 'string', 'string'),
(295, 'Ola', 'Eu sou bue bonito'),
(296, 'string', 'string'),
(297, 'string', 'string'),
(298, 'Ola', 'Eu sou bue bonito'),
(299, 'string', 'string'),
(300, 'string', 'string'),
(303, 'atirei', '1'),
(304, 'o pau', '2'),
(305, 'ao', '3'),
(306, 'gato', 's4'),
(369, 'gato', 's4'),
(370, 'ao', '3'),
(371, 'o pau', '2'),
(372, 'atirei', '1'),
(373, 'string', 'string'),
(374, 'string', 'string'),
(375, 'Ola', 'Eu sou bue bonito'),
(376, 'string', 'string'),
(377, 'string', 'string'),
(378, 'Ola', 'Eu sou bue bonito'),
(379, 'string', 'string'),
(380, 'string', 'string'),
(381, 'try3', '3'),
(382, 'try4', 's4'),
(383, 'atirei', '1'),
(384, 'o pau', '2'),
(385, 'ao', '3'),
(386, 'gato', 's4'),
(387, 'gato', 's4'),
(388, 'ao', '3'),
(389, 'o pau', '2'),
(390, 'atirei', '1'),
(391, 'try4', 's4'),
(392, 'try3', '3'),
(393, 'string', 'string'),
(394, 'string', 'string'),
(395, 'Ola', 'Eu sou bue bonito'),
(396, 'string', 'string'),
(397, 'Ola', 'Eu sou bue bonito'),
(398, 'string', 'string'),
(399, 'string', 'string'),
(400, 'try3', '3'),
(401, 'try4', 's4'),
(402, 'atirei', '1'),
(403, 'o pau', '2'),
(404, 'gato', 's4'),
(405, 'gato', 's4'),
(406, 'ao', '3'),
(407, 'o pau', '2'),
(408, 'atirei', '1'),
(409, 'try4', 's4'),
(410, 'try3', '3'),
(411, 'string', 'string'),
(412, 'string', 'string'),
(413, 'Ola', 'Eu sou bue bonito'),
(414, 'string', 'string'),
(415, 'string', 'string'),
(416, 'string', 'string'),
(417, 'string', 'string'),
(418, 'string', 'string'),
(419, 'string', 'string'),
(420, 'string', 'string'),
(421, 'string', 'string'),
(422, 'string', 'string'),
(423, 'string', 'string'),
(424, 'string', 'string'),
(425, 'string', 'string'),
(426, 'string', 'string'),
(427, 'Ola', 'Eu sou bue bonito'),
(428, 'string', 'string'),
(429, 'string', 'string'),
(430, 'try3', '3'),
(431, 'try4', 's4'),
(432, 'atirei', '1'),
(433, 'o pau', '2'),
(434, 'ao', '3'),
(435, 'gato', 's4'),
(436, 'gato', 's4'),
(437, 'o pau', '2'),
(438, 'atirei', '1'),
(439, 'try4', 's4'),
(440, 'try3', '3'),
(441, 'string', 'string'),
(442, 'string', 'string'),
(443, 'Ola', 'Eu sou bue bonito'),
(444, 'string', 'string'),
(445, 'Ola', 'Eu sou bue bonito'),
(446, 'string', 'string'),
(447, 'string', 'string'),
(448, 'try3', '3'),
(449, 'try4', 's4'),
(450, 'atirei', '1'),
(451, 'o pau', '2'),
(452, 'ao', '3'),
(453, 'gato', 's4'),
(454, 'gato', 's4'),
(455, 'ao', '3'),
(456, 'o pau', '2'),
(457, 'atirei', '1'),
(458, 'try4', 's4'),
(459, 'try3', '3'),
(460, 'string', 'string'),
(461, 'string', 'string'),
(462, 'Ola', 'Eu sou bue bonito'),
(463, 'string', 'string'),
(464, 'string', 'string'),
(465, 'Ola', 'Eu sou bue bonito'),
(466, 'string', 'string'),
(467, 'string', 'string'),
(468, 'try3', '3'),
(469, 'try4', 's4'),
(470, 'atirei', '1'),
(471, 'o pau', '2'),
(472, 'ao', '3'),
(473, 'gato', 's4'),
(474, 'string', 'string'),
(475, 'Ola', 'Eu sou bue bonito'),
(476, 'string', 'string'),
(477, 'string', 'string'),
(478, 'try3', '3'),
(479, 'try4', 's4'),
(480, 'atirei', '1'),
(481, 'o pau', '2'),
(482, 'ao', '3'),
(483, 'gato', 's4'),
(484, 'string', 'string'),
(485, 'Ola', 'Eu sou bue bonito'),
(486, 'string', 'string'),
(487, 'string', 'string'),
(488, 'try3', '3'),
(489, 'try4', 's4'),
(490, 'atirei', '1'),
(491, 'o pau', '2'),
(492, 'ao', '3'),
(493, 'gato', 's4'),
(494, 'string', 'string'),
(495, 'Ola', 'Eu sou bue bonito'),
(496, 'string', 'string'),
(497, 'string', 'string'),
(498, 'try3', '3'),
(499, 'try4', 's4'),
(500, 'atirei', '1'),
(501, 'o pau', '2'),
(502, 'ao', '3'),
(503, 'gato', 's4'),
(504, 'string', 'string'),
(505, 'Ola', 'Eu sou bue bonito'),
(506, 'string', 'string'),
(507, 'string', 'string'),
(508, 'try3', '3'),
(509, 'try4', 's4'),
(510, 'atirei', '1'),
(511, 'o pau', '2'),
(512, 'ao', '3'),
(513, 'gato', 's4'),
(514, 'string', 'string'),
(515, 'Ola', 'Eu sou bue bonito'),
(516, 'string', 'string'),
(517, 'string', 'string'),
(518, 'try3', '3'),
(519, 'try4', 's4'),
(520, 'atirei', '1'),
(521, 'o pau', '2'),
(522, 'ao', '3'),
(523, 'gato', 's4'),
(524, 'gato', 's4'),
(525, 'ao', '3'),
(526, 'o pau', '2'),
(527, 'atirei', '1'),
(529, 'asd', 'asd');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`Id`, `username`, `password`) VALUES
(1, 'artur', 'gelado123'),
(4, 'armando', 'quimbe'),
(5, 'abc', '123'),
(6, 'username', 'password'),
(7, 'string', 'string'),
(8, 'adolfo', 'ambrosio'),
(9, 'raul', '123'),
(10, 'asd', 'asd'),
(11, 'dssd', 'sdsd'),
(12, 'dssd', 'sdsd'),
(13, 'qwe', 'qwe'),
(14, 'asd', 'asd'),
(15, 'asd', 'asd'),
(16, 'asd', 'asd'),
(17, 'asd', 'asd'),
(18, 'asd', 'asd'),
(19, 'asd', 'asd');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `blogpost`
--
ALTER TABLE `blogpost`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `blogpost`
--
ALTER TABLE `blogpost`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=530;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
