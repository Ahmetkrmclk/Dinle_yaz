-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 08 Haz 2022, 22:41:42
-- Sunucu sürümü: 10.4.14-MariaDB
-- PHP Sürümü: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `listen_write`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `ad` varchar(45) DEFAULT NULL,
  `sifre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `ad`, `sifre`) VALUES
(1, 'Ahmet_Kerim', '123');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `alm_kolay`
--

CREATE TABLE `alm_kolay` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `alm_kolay`
--

INSERT INTO `alm_kolay` (`id`, `isim`, `skor`) VALUES
(1, 'Ahmet_Kerim', 75);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `alm_orta`
--

CREATE TABLE `alm_orta` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `alm_orta`
--

INSERT INTO `alm_orta` (`id`, `isim`, `skor`) VALUES
(1, 'Ahmetkrmclk', 150);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `alm_zor`
--

CREATE TABLE `alm_zor` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `alm_zor`
--

INSERT INTO `alm_zor` (`id`, `isim`, `skor`) VALUES
(1, 'Ahmetkrmclk', 300);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `eksta_ak`
--

CREATE TABLE `eksta_ak` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `eksta_ak`
--

INSERT INTO `eksta_ak` (`id`, `isim`, `skor`) VALUES
(1, 'Deneme_Kullanıcı', 45),
(2, 'Deneme_Kullanıcı', 55),
(3, 'Deneme3', 75),
(4, 'RasgeleDEneme', 60);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `eksta_ik`
--

CREATE TABLE `eksta_ik` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `eksta_ik`
--

INSERT INTO `eksta_ik` (`id`, `isim`, `skor`) VALUES
(1, 'deneme', 50),
(2, 'Deneme_Kullanıcı', 55),
(3, 'deneme3', 115),
(4, 'Gece_Denemesi', 110),
(5, 'skor', 95),
(6, 'calisti', 100);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ekstra_a`
--

CREATE TABLE `ekstra_a` (
  `id` int(11) NOT NULL,
  `ses_dosyası` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `ekstra_a`
--

INSERT INTO `ekstra_a` (`id`, `ses_dosyası`, `yazilisi`) VALUES
(1, 'Alle fünf Minuten gibt es eine U-Bahn in der Innenstadt.mp3', 'Alle fünf Minuten gibt es eine U-Bahn in der Innenstadt'),
(2, 'Ich wünsche Ihnen einen schönen Hochzeitstag.mp3', 'Ich wünsche Ihnen einen schönen Hochzeitstag'),
(3, 'Ihr Ticket und Reisepass bitte.mp3', 'Ihr Ticket und Reisepass bitte'),
(4, 'Möchten Sie mit mir essen.mp3', 'Möchten Sie mit mir essen'),
(5, 'Welchen Sport machst du.mp3', 'Welchen Sport machst du'),
(6, 'Wie heißt du.mp3', 'Wie heibt du');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ekstra_i`
--

CREATE TABLE `ekstra_i` (
  `id` int(11) NOT NULL,
  `ses_dosyasi` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `ekstra_i`
--

INSERT INTO `ekstra_i` (`id`, `ses_dosyasi`, `yazilisi`) VALUES
(1, 'Can I ask you something.mp3', 'Can I ask you something'),
(2, 'Hamza is older than Ahmet.mp3', 'Hamza is older than Ahmet'),
(3, 'I don’t understand.mp3', 'I don’t understand'),
(4, 'Learning English is easier than learning Chinese.mp3', 'Learning English is easier than learning Chinese'),
(5, 'Maybe I am happier than you.mp3', 'Maybe I am happier than you'),
(6, 'My name is Serpil..mp3', 'My name is Serpil'),
(7, 'Talk to you tomorrow.mp3', 'Talk to you tomorrow'),
(8, 'What is your name.mp3', 'What is your name'),
(9, 'Which bus do you want.mp3', 'Which bus do you want'),
(10, 'I don’t have time.mp3', 'I don’t have time');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ing_kolay`
--

CREATE TABLE `ing_kolay` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `ing_kolay`
--

INSERT INTO `ing_kolay` (`id`, `isim`, `skor`) VALUES
(1, 'Ahmet_Kerim', 75),
(2, 'Cansu', 80),
(3, 'Deneme', 75),
(4, 'Ahmet Kerim', 75),
(5, 'deneme11', 75);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ing_orta`
--

CREATE TABLE `ing_orta` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `ing_orta`
--

INSERT INTO `ing_orta` (`id`, `isim`, `skor`) VALUES
(1, 'Ahmet_Kerim', 150);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ing_zor`
--

CREATE TABLE `ing_zor` (
  `id` int(11) NOT NULL,
  `isim` varchar(45) DEFAULT NULL,
  `skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `ing_zor`
--

INSERT INTO `ing_zor` (`id`, `isim`, `skor`) VALUES
(1, 'Ahmet_Kerim', 225);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kelimeler_ak`
--

CREATE TABLE `kelimeler_ak` (
  `id` int(11) NOT NULL,
  `kelimeler` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kelimeler_ak`
--

INSERT INTO `kelimeler_ak` (`id`, `kelimeler`, `yazilisi`) VALUES
(1, 'Acht', 'Acht'),
(2, 'Auf Wiedersehen', 'Auf Wiedersehen'),
(3, 'Aufzug', 'Aufzug'),
(4, 'Da drüben', 'Da drüben'),
(5, 'Geschieden', 'Geschieden'),
(6, 'Hallo', 'Hallo'),
(7, 'Herzlich willkommen', 'Herzlich willkommen'),
(8, 'Heute Morgen', 'Heute Morgen'),
(9, 'Hinter', 'Hinter'),
(10, 'ich bin türkisch', 'İch bin türkisch'),
(11, 'Kurz', 'Kurz'),
(12, 'Nein', 'Nein'),
(13, 'Nichts zu danken', 'Nichts zu danken'),
(14, 'Niederlandisch', 'Niederlandisch'),
(15, 'Verheiratet', 'Verheiratet');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kelimeler_ao`
--

CREATE TABLE `kelimeler_ao` (
  `id` int(11) NOT NULL,
  `kelimeler` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kelimeler_ao`
--

INSERT INTO `kelimeler_ao` (`id`, `kelimeler`, `yazilisi`) VALUES
(1, 'ansonsten', 'Ansonsten'),
(2, 'beabsichtigen', 'Beabsichtigen'),
(3, 'bestechen', 'Bestechen'),
(4, 'der Feiertag', 'Der Feiertag'),
(5, 'der Führerschein', 'Der Führerschein'),
(6, 'die Heimatstadt', 'Die Heimatstadt'),
(7, 'erfüllen', 'Erfüllen'),
(8, 'historisch', 'Historisch'),
(9, 'kauen', 'Kauen'),
(10, 'Passen', 'Passen'),
(11, 'sich beeilen', 'Sich beeilen'),
(12, 'unterhaltsam', 'Unterhaltsam'),
(13, 'wirksam', 'Wirksam'),
(14, 'wirtschaftlich', 'Wirtschaftlich'),
(15, 'zum Schluss', 'Zum Schluss');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kelimeler_az`
--

CREATE TABLE `kelimeler_az` (
  `id` int(11) NOT NULL,
  `kelimeler` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kelimeler_az`
--

INSERT INTO `kelimeler_az` (`id`, `kelimeler`, `yazilisi`) VALUES
(1, 'auftauchen', 'Auftauchen'),
(2, 'augenblicklich', 'Augenblicklich'),
(3, 'befestigt', 'Befestigt'),
(4, 'bezüglich', 'Bezüglich'),
(5, 'das Chaos', 'Das Chaos'),
(6, 'der verbale Übergriff', 'Der verbale Übergriff'),
(7, 'ehrenamtlich', 'Ehrenamtlich'),
(8, 'eingeschnappt sein', 'Eingeschnappt sein'),
(9, 'gewaltigt', 'Gewaltigt'),
(10, 'herunterstufen', 'Herunterstufen'),
(11, 'insofern', 'İnsofern'),
(12, 'je nach Bedarf', 'Je nach Bedarf'),
(13, 'kontaktieren', 'Kontaktieren'),
(14, 'lagern', 'Lagern'),
(15, 'scheitern', 'Scheitern');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kelimeler_ik`
--

CREATE TABLE `kelimeler_ik` (
  `id` int(11) NOT NULL,
  `kelimeler` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kelimeler_ik`
--

INSERT INTO `kelimeler_ik` (`id`, `kelimeler`, `yazilisi`) VALUES
(1, 'After', 'After'),
(2, 'Again', 'Again'),
(3, 'All', 'All'),
(4, 'Always', 'Always'),
(5, 'Another', 'Another'),
(6, 'Ask', 'Ask'),
(7, 'Be', 'Be'),
(8, 'Before', 'Before'),
(9, 'Begin', 'Begin'),
(10, 'Buy', 'Buy'),
(11, 'Change', 'Change'),
(12, 'Cheap', 'Cheap'),
(13, 'Contiune', 'Contiune'),
(14, 'Drive', 'Drive'),
(15, 'Different', 'Different');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kelimeler_io`
--

CREATE TABLE `kelimeler_io` (
  `id` int(11) NOT NULL,
  `kelimeler` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kelimeler_io`
--

INSERT INTO `kelimeler_io` (`id`, `kelimeler`, `yazilisi`) VALUES
(1, 'Announce', 'Announce'),
(2, 'Apologise', 'Apologise'),
(3, 'Dream', 'Dream'),
(4, 'Follow', 'Follow'),
(5, 'Grandfather', 'Grandfather'),
(6, 'Ignore', 'Ignore'),
(7, 'Offer', 'Offer'),
(8, 'Sing', 'Sing'),
(9, 'Sister', 'Sister'),
(10, 'Suppose', 'Suppose'),
(11, 'Swim', 'Swim'),
(12, 'Tranport', 'Tranport'),
(13, 'Twist', 'Twist'),
(14, 'Unite', 'Unite'),
(15, 'Walk', 'Walk');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kelimeler_iz`
--

CREATE TABLE `kelimeler_iz` (
  `id` int(11) NOT NULL,
  `kelimeler` varchar(1000) DEFAULT NULL,
  `yazilisi` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kelimeler_iz`
--

INSERT INTO `kelimeler_iz` (`id`, `kelimeler`, `yazilisi`) VALUES
(1, 'Brewery', 'Brewery'),
(2, 'Congratulations', 'Congratulations'),
(3, 'Craftsman', 'Craftsman'),
(4, 'Deteriorate', 'Deteriorate'),
(5, 'Entrepreneurial', 'Entrepreneurial'),
(6, 'Explicit', 'Explicit'),
(7, 'Extraterrestrial', 'Extraterrestrial'),
(8, 'February', 'February'),
(9, 'Handkerchief', 'Handkerchief'),
(10, 'Irregardless', 'Irregardless'),
(11, 'Lieutenant', 'Lieutenant'),
(12, 'Prejudice', 'Prejudice'),
(13, 'Psychiatrist', 'Psychiatrist'),
(14, 'Rhythm', 'Rhythm'),
(15, 'Schedule', 'Schedule');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `alm_kolay`
--
ALTER TABLE `alm_kolay`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `alm_orta`
--
ALTER TABLE `alm_orta`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `alm_zor`
--
ALTER TABLE `alm_zor`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `eksta_ak`
--
ALTER TABLE `eksta_ak`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `eksta_ik`
--
ALTER TABLE `eksta_ik`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `ekstra_a`
--
ALTER TABLE `ekstra_a`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `ekstra_i`
--
ALTER TABLE `ekstra_i`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `ing_kolay`
--
ALTER TABLE `ing_kolay`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `ing_orta`
--
ALTER TABLE `ing_orta`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `ing_zor`
--
ALTER TABLE `ing_zor`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kelimeler_ak`
--
ALTER TABLE `kelimeler_ak`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kelimeler_ao`
--
ALTER TABLE `kelimeler_ao`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kelimeler_az`
--
ALTER TABLE `kelimeler_az`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kelimeler_ik`
--
ALTER TABLE `kelimeler_ik`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kelimeler_io`
--
ALTER TABLE `kelimeler_io`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kelimeler_iz`
--
ALTER TABLE `kelimeler_iz`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `alm_kolay`
--
ALTER TABLE `alm_kolay`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `alm_orta`
--
ALTER TABLE `alm_orta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `alm_zor`
--
ALTER TABLE `alm_zor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `eksta_ak`
--
ALTER TABLE `eksta_ak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `eksta_ik`
--
ALTER TABLE `eksta_ik`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `ekstra_a`
--
ALTER TABLE `ekstra_a`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `ekstra_i`
--
ALTER TABLE `ekstra_i`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `ing_kolay`
--
ALTER TABLE `ing_kolay`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `ing_orta`
--
ALTER TABLE `ing_orta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `ing_zor`
--
ALTER TABLE `ing_zor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `kelimeler_ak`
--
ALTER TABLE `kelimeler_ak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `kelimeler_ao`
--
ALTER TABLE `kelimeler_ao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `kelimeler_az`
--
ALTER TABLE `kelimeler_az`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `kelimeler_ik`
--
ALTER TABLE `kelimeler_ik`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `kelimeler_io`
--
ALTER TABLE `kelimeler_io`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `kelimeler_iz`
--
ALTER TABLE `kelimeler_iz`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
