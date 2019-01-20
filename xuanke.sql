/*
Navicat MySQL Data Transfer

Source Server         : MySQL
Source Server Version : 50710
Source Host           : localhost:3307
Source Database       : xuanke

Target Server Type    : MYSQL
Target Server Version : 50710
File Encoding         : 65001

Date: 2019-01-20 12:41:12
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for admin
-- ----------------------------
DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin` (
  `admin_num` varchar(255) NOT NULL,
  `password` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`admin_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of admin
-- ----------------------------
INSERT INTO `admin` VALUES ('12', '123');

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course` (
  `Course_num` varchar(11) NOT NULL,
  `Course_name` varchar(255) DEFAULT NULL,
  `credit_hour` varchar(255) DEFAULT NULL,
  `type` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `time_week` varchar(255) DEFAULT NULL,
  `time_jie` varchar(255) DEFAULT NULL,
  `academy` varchar(255) DEFAULT NULL,
  `maxcount` int(255) DEFAULT '0',
  `teacher_num` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Course_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES ('12', 'java设计', '2', '必修', '基教', '周二', '5-6节', '信息科学与技术学院', '60', '5');
INSERT INTO `course` VALUES ('13', '23', '23', '任选', '23', '周三', '3-4节', '信息科学与技术学院', '23', '9');

-- ----------------------------
-- Table structure for result
-- ----------------------------
DROP TABLE IF EXISTS `result`;
CREATE TABLE `result` (
  `result_num` int(11) NOT NULL AUTO_INCREMENT,
  `student_num` varchar(11) DEFAULT NULL,
  `course_num` varchar(11) DEFAULT NULL,
  `score` double(255,0) DEFAULT NULL,
  `type` varchar(255) DEFAULT NULL,
  `year` varchar(255) DEFAULT NULL,
  `term` varchar(255) DEFAULT NULL,
  `state` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`result_num`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of result
-- ----------------------------
INSERT INTO `result` VALUES ('20', '20163626', '12', '12', null, '2019', '春', '审核已通过');

-- ----------------------------
-- Table structure for student
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student` (
  `student_num` varchar(8) NOT NULL,
  `student_name` varchar(255) DEFAULT NULL,
  `student_academy` varchar(255) DEFAULT NULL,
  `student_grade` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `profession` varchar(255) DEFAULT NULL,
  `id_number` varchar(255) DEFAULT NULL,
  `classs` varchar(255) DEFAULT NULL,
  `telephone` varchar(255) DEFAULT NULL,
  `sushe` varchar(255) DEFAULT NULL,
  `zhuzhi` varchar(255) DEFAULT NULL,
  `shengao` varchar(255) DEFAULT NULL,
  `tizhong` varchar(255) DEFAULT NULL,
  `aihao` varchar(255) DEFAULT NULL,
  `techang` varchar(255) DEFAULT NULL,
  `m_telephone` varchar(255) DEFAULT NULL,
  `f_telephone` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`student_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of student
-- ----------------------------
INSERT INTO `student` VALUES ('20163626', '张魏', '信息科学与技术学院', '大二', '345678', '男', '软件工程', '123456789012345678', '信1605-5', null, null, null, null, null, null, null, null, null);
INSERT INTO `student` VALUES ('20163628', '捺印', '电气与电子学院', '大三', '345678', '男', '电子设计', '123456789012345678', '电1602-1', null, null, null, null, null, null, null, null, null);
INSERT INTO `student` VALUES ('20163629', '小兰', '机械工程学院', '大二', '345678', '女', '画图', '123456789012345678', '机1306-1', null, null, null, null, null, null, null, null, null);
INSERT INTO `student` VALUES ('20163630', '小刚', '土木工程学院', '大三', '345678', '男', '土木工程', '123456789012345678', '土1503-1', null, null, null, null, null, null, null, null, null);
INSERT INTO `student` VALUES ('20163631', '夏鸥', '交通运输学院', '大二', '345678', '男', '交通', '123456789012345678', '交1353-1', null, null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for teacher
-- ----------------------------
DROP TABLE IF EXISTS `teacher`;
CREATE TABLE `teacher` (
  `teacher_num` varchar(255) NOT NULL,
  `teacher_name` varchar(255) DEFAULT NULL,
  `teacher_academy` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `profession` varchar(255) DEFAULT NULL,
  `id_number` varchar(255) DEFAULT NULL,
  `zhuzhi` varchar(255) DEFAULT NULL,
  `aihao` varchar(255) DEFAULT NULL,
  `telephone` varchar(255) DEFAULT NULL,
  `office` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`teacher_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of teacher
-- ----------------------------
INSERT INTO `teacher` VALUES ('10', '张迪', '建筑与艺术学院', '345678', '男', '技艺', '123456789012345678', null, null, null, null);
INSERT INTO `teacher` VALUES ('20172343', '袁雅琴', '信息科学与技术学院', '201724', '女', '软件工程', '640321199611201724', null, null, null, null);
INSERT INTO `teacher` VALUES ('4', '阿迪', '建筑与艺术学院', '345678', '女', '软件工程', '123456789012345678', null, null, null, null);
INSERT INTO `teacher` VALUES ('5', '小娜', '信息科学与技术学院', '345678', '女', '软件工程', '123456789012345678', null, null, null, null);
INSERT INTO `teacher` VALUES ('6', '王云玲', '材料科学与工程学院', '345678', '女', '材料分析', '123456789012345678', null, null, null, null);
INSERT INTO `teacher` VALUES ('7', '纳音', '经济管理学院', '345678', '女', '材料', '123456789012345678', null, null, null, null);
INSERT INTO `teacher` VALUES ('8', '娜娜', '电气与电子学院', '345678', '男', '软件工程', '123456789012345678', null, null, null, null);
INSERT INTO `teacher` VALUES ('9', '纳音', '信息科学与技术学院', '345678', '男', '12', '123456789012345678', null, null, null, null);
