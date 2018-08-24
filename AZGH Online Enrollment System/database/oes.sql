create database oes;
use oes;

CREATE TABLE `tblaccount` (
	`AccountID` int(11) NOT NULL AUTO_INCREMENT,
	`Username` varchar(50) NOT NULL,
	`Password` varchar(50) NOT NULL,
	`User_Status` varchar(15) NOT NULL,
    PRIMARY KEY(`AccountID`)
);

INSERT INTO `tblaccount` (`AccountID`, `User_name`, `Pass_word`, `User_Status`) VALUES
(1, 'stud', '1a1dc91c907325c69271ddf0c944bc72', 'student'),
(2, 'admin', '21232f297a57a5a743894a0e4a801fc3', 'admin'),
(3, 'faculty', 'd561c7c03c1f2831904823a95835ff5f', 'faculty');

CREATE TABLE `tblquestion` (
	`QuestionID` int(11) NOT NULL AUTO_INCREMENT,
	`Question` varchar(100) NOT NULL,
    PRIMARY KEY(`QuestionID`)
);

INSERT INTO `tblquestion` (`QuestionID`, `Question`) VALUES
(1, 'At what age did your childhood pet run away?'),
(2, 'What is the maiden name of your fathers mistress?'),
(3, 'What sports team do you fetishize to avoid meaningful discussion with others?'),
(4, 'What is the name of your favorite canceled TV show?'),
(5, 'On what street did you lose your childlike sense of wonder?'),
(6, 'What is the last name of the teacher who gave you your first failing grade?'),
(7, 'What was the name of your elementary / primary school?'),
(8, 'What time of the day were you born?'),
(9, 'What is your favorite book ?'),
(10, 'What was your childhood nickname?'),
(11, 'In what city did you meet your spouse/significant other?'),
(12, 'What is the name of your favorite childhood friend?'),
(13, 'What street did you live on in third grade?'),
(14, 'What is your oldest siblings birthday month and year?'),
(15, 'What is the middle name of your oldest child?'),
(16, 'What is your oldest siblings middle name?'),
(17, 'What school did you attend for sixth grade?'),
(18, 'What was your childhood phone number including area code?'),
(19, 'What is your oldest cousins first and last name?'),
(20, 'What was the name of your first stuffed animal?'),
(21, 'In what city or town did your mother and father meet?'),
(22, 'Where were you when you had your first kiss?'),
(23, 'What is the first name of the boy or girl that you first kissed?'),
(24, 'What was the last name of your third grade teacher?'),
(25, 'In what city does your nearest sibling live?'),
(26, 'What is your oldest brother’s birthday month and year?'),
(27, 'What is your maternal grandmother''s maiden name?'),
(28, 'In what city or town was your first job?'),
(29, 'What is the name of the place your wedding reception was held?'),
(30, 'What is the name of a college you applied to but didn''t attend?'),
(31, 'Where were you when you first heard about 9/11?');

CREATE TABLE `tblanswer` (
	`AccountID` int(11) NOT NULL,
	`QuestionID` int(11) NOT NULL,
	`Answer` varchar(100) NOT NULL,
    UNIQUE KEY(`AccountID`)
);

INSERT INTO `tblanswer` (`AccountID`, `QuestionID`, `Answer`) VALUES
(1, 9, 'Math'),
(2, 9, 'Science'),
(3, 22, 'secret');


CREATE TABLE `tblanswerview` (
	`AccountID` int(11),
	`User_name` varchar(50),
	`Question` varchar(100),
    `Answer` varchar(100)
);

DROP table IF EXISTS `tblanswerview`;

CREATE ALGORITHM = UNDEFINED DEFINER = `root`@`localhost`
SQL SECURITY DEFINER VIEW 
`tblanswerview`  AS  SELECT 
`c`.`AccountID` AS `AccountID`,
`c`.`Username` AS `Username`,
`q`.`Question` AS `Question`,
`a`.`Answer` AS `Answer` 
from ((`tblanswer` `a` join `tblquestion` `q` on((`q`.`QuestionID` = `a`.`QuestionID`))) 
join `tblaccount` `c` on((`c`.`AccountID` = `a`.`AccountID`)));

    
    
    
    
    
    
    
    
    