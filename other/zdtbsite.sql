/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50705
Source Host           : localhost:3306
Source Database       : zdtbsite

Target Server Type    : MYSQL
Target Server Version : 50705
File Encoding         : 65001

Date: 2014-12-12 22:09:55
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for adminmenus
-- ----------------------------
DROP TABLE IF EXISTS `adminmenus`;
CREATE TABLE `adminmenus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) NOT NULL,
  `Name` varchar(64) DEFAULT NULL,
  `Url` varchar(64) DEFAULT NULL,
  `Action` varchar(64) DEFAULT NULL,
  `Controller` varchar(64) DEFAULT NULL,
  `Discretion` varchar(512) DEFAULT NULL,
  `Icon` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of adminmenus
-- ----------------------------
INSERT INTO `adminmenus` VALUES ('1', '0', '用户模块', '#', '', '', '维护用户信息', 'icon-user');
INSERT INTO `adminmenus` VALUES ('2', '1', '用户管理', '/User/Index', 'Index', 'User', '用户维护，重置密码，权限分配等', '');
INSERT INTO `adminmenus` VALUES ('3', '0', '文章发布', '#', '', '', '文章信息维护，技术文章，新闻发布，文章采集', 'icon-envelope');
INSERT INTO `adminmenus` VALUES ('4', '3', '技术文章', '#', 'Index', 'Article', '技术文章发布，编辑，删除等', '');
INSERT INTO `adminmenus` VALUES ('5', '3', '新闻发布', '#', '', null, '行业新闻发布，编辑，删除等', null);
INSERT INTO `adminmenus` VALUES ('6', '3', '文章采集', '#', 'Index', 'NewsCrawler', '自动更新行业类新闻，预览更新的新闻', null);
INSERT INTO `adminmenus` VALUES ('7', '0', '产品模块', '#', 'Index', 'Product', '产品信息的维护', 'icon-check');
INSERT INTO `adminmenus` VALUES ('8', '7', '类型维护', '#', 'Index', 'ProductType', '产品类型的维护，添加，编辑，删除', '');
INSERT INTO `adminmenus` VALUES ('9', '7', '产品发布', '#', 'Index', 'Product', '产品的维护，发布，编辑，删除等产品', '');
INSERT INTO `adminmenus` VALUES ('10', '0', '企业信息', '#', 'Index', 'BasicInfo', '企业信息维护', 'icon-home');
INSERT INTO `adminmenus` VALUES ('11', '0', '客户追踪', '#', '', '', '客户在本网站的使用信息追踪', 'icon-star-empty');
INSERT INTO `adminmenus` VALUES ('12', '11', '合同管理', '#', 'Index', 'Contract', '客户预支款维护等', null);
INSERT INTO `adminmenus` VALUES ('13', '11', '客户信息', '#', 'Index', 'Customer', '客户基本信息浏览', null);
INSERT INTO `adminmenus` VALUES ('14', '11', '产品浏览信息', '#', 'Index', 'Visit', '客户浏览的产品情况', null);
INSERT INTO `adminmenus` VALUES ('15', '11', '留言预览', '#', 'Index', 'Feedback', '客户留言预览', null);
INSERT INTO `adminmenus` VALUES ('16', '0', '人才管理', '#', '', '', '公司企业的人才管理', 'icon-briefcase');
INSERT INTO `adminmenus` VALUES ('17', '16', '职位发布', '#', 'Index', 'Recruitment', '公司所缺的职位招聘信息', null);

-- ----------------------------
-- Table structure for articles
-- ----------------------------
DROP TABLE IF EXISTS `articles`;
CREATE TABLE `articles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(512) DEFAULT NULL,
  `Publisher` varchar(128) DEFAULT NULL,
  `PublisherDateTime` datetime NOT NULL,
  `UpdateDateTime` datetime NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `OriginArticlesType` int(11) NOT NULL,
  `Content` longtext,
  `ContentTyepId` int(11) NOT NULL,
  `Tag` varchar(256) DEFAULT NULL,
  `ImgUrl` varchar(1024) DEFAULT NULL,
  `ThumbnailUrl` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ContentTyepId` (`ContentTyepId`) USING HASH,
  CONSTRAINT `FK_articles_ContentTypes_ContentTyepId` FOREIGN KEY (`ContentTyepId`) REFERENCES `contenttypes` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of articles
-- ----------------------------
INSERT INTO `articles` VALUES ('42', 'Transformer Oil Maintenance', null, '2014-12-10 21:42:23', '2014-12-10 21:42:23', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">Transformer Oil Maintenance</h1>\r\n\r\n		\r\n				\r\n		Energy transformers are critical components of the energy distribution grid and it is therefore important to have a monitoring and maintenance plan in place to preempt their failure. One of the critical components of an energy transformer is the transformer oil. \n A transformer operates in a moisture free environment and even the slightest moisture can seriously reduce its life. Most companies have an oil maintenance schedule to monitor the condition of oil and detect a problem before it causes extensive damage. Oil testing during maintenance also helps detect problems like contact arcing, aging insulating paper and other latent faults. \n   \n  Steps for Collecting Oil Sample for Transformer Oil Testing:  \n Oil testing is a critical process it can be done before the transformer start-up, during a routine transformer inspection or in any circumstances indicating possibility of damage to the transformer, particularly when a protective device is triggered. \n To collect an oil sample a sampling valve located near the bottom of the tank is used. Transformer oil is a hygroscopic substance and must be protected from contact with moisture. It is therefore important to place the collected oil sample in a clean dry container. \n   \n  Oil Treatment Guidelines  \n Following are the oil treatment guidelines which can prolong the life of transformer and save a company thousands of dollars: \n \n     Purify when the acid level is still low, i.e. <0.1 mg \n     Regenerate preferably from 0.1 mg KOH/g oil to avoid precipitation of sludge \n     De-sludge when the acid level is >0.20 mg KOH/g oil \n     Dry-out when the solid insulation is wet >3.5 % MDW \n \n  Purification, a method of transformer oil maintenance  \n Purification is the process by which moisture and gasses are removed from the insulating oil. This process readily dries up the oil but not the insulation system, this is because the drying depends on the rate of diffusion of water through the paper into the oil, which is slow. Frequent processing is necessary to attain the degree of dryness desired in the cellulose insulation. \n Even though the purification method is not the best, it is an effective moisture management tool. It is used widely in the industry to effectively reduce the moisture content and elevate the dielectric strength of the oil in wet core situations.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/btDliW4UAhI\" height=\"1\" width=\"1\"/>					</article>', '2', 'Transformer Oil Maintenance', null, null);
INSERT INTO `articles` VALUES ('43', 'NFPA Compliance and Electrical Transformers', null, '2014-12-10 21:42:30', '2014-12-10 21:42:30', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">NFPA Compliance and Electrical Transformers</h1>\r\n\r\n		\r\n				\r\n		Even though energy transformers typically deal with hazardous levels of electricity, they are often located in or near fairly public places. Their safety is thus a matter of much concern. For this reason, requirements for electrical transformers and employees working with them are included in NFPA 70 and 70E. \n All electrical wiring and equipment has to be in accordance with NFPA 70. With electricity being hazardous, employees working with transformers are also subject to protection in accordance with 70E, unless it is an existing installation, which may be permitted to continue in service, subject to approval by the authority having jurisdiction over it. \n Below are some of the key provisions relative to transformers mentioned in NFPA 70: \n Individual dry-type transformers of more than 112 kVA rating should be installed in a transformer room of fire-resistant construction having a minimum fire rating of 1 hour. Transformers not over 112 kVA have no specific installation requirements for the room in which they are located. \n Dry-type transformers rated over 35,000 volts should be installed in a vault with minimum fire resistance of 3 hours. Each doorway leading into a vault from the building interior should have a tight fitting door that has a minimum fire rating of 3 hours. Exception: Where transformers are protected with automatic sprinkler, water spray, carbon dioxide, or halon, construction of 1-hour rating shall be permitted. \n   \n  About NFPA 70E  \n The NFPA 70E standard addresses the electrical safety requirements for all employees who install, maintain and repair electrical systems. It recognizes the hazards associated with the use of electrical energy and includes guidelines to take precautions against injury or death. \n Compliance to NFPA 70E requires that all personnel working on electrical equipment operating at >50V should wear arc-flash protective garments to prevent injury. Arc-flash is an electric current that passes through the air when the insulation between electrified conductors can no longer withstand an applied voltage. A flash can last less than a second and its results can be severe and even lead to fatalities. \n   \n  NFPA 70E Compliance Checklist  \n Implementation of NFPA 70E regulations is a major challenge. The arc flash analysis requires training and tools to implement the program. \n Below is a checklist to establish NEPA 70E Compliance \n   \n  Short-Term Action  \n \n     Electricians, maintenance mechanics and facilities repair workers are not to work on hot/live equipment wearing all-cotton clothing \n     Electricians, maintenance mechanics and facilities repair workers should work as much as possible on de-energized equipment. \n     Employees are to use interim hazard warning labels on electrical equipment. \n \n  Long-Term Action  \n \n     Electrical workers are to be trained in Arc-flash Hazard Awareness. \n     Existing Logout/Tagout (LOTO) procedures are to be periodically reviewed to make certain they include all control panels. \n     The LOTO training of previous employees to be assessed to determine if they need to be retrained. \n     Periodic tool audits to be conducted to ensure employees have the required tools for their safety and replacement of missing tools. \n     Reviewing those employees have clothing appropriate for electrical work. \n     Arc-flash hazard analysis to be conducted to determine flash protection boundary on switchboards, panel boards, industrial control panels, motor control centers, other similar equipment. \n \n So if you are planning to buy a transformer, you might want to ensure your transformer is NFPA 70 and 70E compliant, and pay some special attention to transformer security and safety of employees working with them. \n Pacific Crest Transformers, with its years of experience on safety, advises those buying transformers from them on how to comply by the required legislation, so that risk of any kind is minimized.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/Knr5dUqfn4A\" height=\"1\" width=\"1\"/>					</article>', '2', 'NFPA Compliance and Electrical Transformers', null, null);
INSERT INTO `articles` VALUES ('44', 'Aging Power Infrastructure in the US', null, '2014-12-10 21:45:57', '2014-12-10 21:45:57', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">Aging Power Infrastructure in the US</h1>\r\n\r\n		\r\n				\r\n		The US electric grid is a mammoth, complex network of independently owned and operated power plants and transmission lines. Most of the currently available infrastructure was put in place across the 1950s and 60s. Its sheer age is now earning commentary like this, on NPR: \n \"The U.S. power grid is often equated to a highway system, one that has been seriously neglected and is now being pushed to its limits with the demands of our growing and changing energy needs. As we see the rise in demand for renewable energy sources to combat the environmental ramifications of fossil fuels, the grid will continue to be proven antiquated and in need of reinvention.\" \n  \nThe Department of Energy estimates that demand for electricity has increased by around 25 % since 1990 while construction of transmission facilities dropped 30%. According to Media Company Red Herring Inc., energy demand in the US is likely to surge 32% by 2015.  \n \nThe grid failure of 2003 that affected the lives of over 50 million people is an oft-quoted example to underline the necessity of modernizing the US power grid. This is not just to deal with growing demand, but also to accommodate the new focus on renewable energy sources like wind, solar and hydro power: which are not easily inter-connectable to the existing grid without significant refurbishing. The goal, of course, is to address long term energy security.  Opting for renewable energy and putting in place infrastructure like \'smart grids\', however, calls for a sizable investment.  \n \nA  key target to reduce energy lost in the distribution process is the emergence of higher efficiency requirements for   power and distribution transformers. Currently,  transformers are responsible for a sizable amount of the energy lost and it is here that the DOE is introducing rules to increase efficiency. According to the rules published by the DOE, the cost of liquid-immersed distribution transformers increases by up to 12%, but should decrease electrical losses by as much as 23%. It could also raise the cost of medium-voltage, dry-type transformers by up to 13%, but should decrease electrical losses by as much as 26%. \nIt is in the area of energy-efficient transformers, and transformers in the alternate energy sector like wind energy that Pacific Crest is making its presence most felt. With over 90 years of continuous experience, PCT has also been a consistent innovator in building custom energy-efficient transformers. This has allowed PCT to keep pace with the new energy-efficient power grid that is replacing the aging infrastructure. Although much of the energy efficient technology is a little more expensive, private and government-owned utilities have begun to invest in it for the reliability it ensures. Additionally, the initial investment more than pays for itself in the long run, due to the decreased energy lost in the transmission and distribution system.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/8CsryJTglsQ\" height=\"1\" width=\"1\"/>					</article>', '2', 'Aging Power Infrastructure in the US', null, null);
INSERT INTO `articles` VALUES ('45', 'Green Technology is the new &#8216;Efficient&#8217;', null, '2014-12-10 21:46:47', '2014-12-10 21:46:47', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">Green Technology is the new &#8216;Efficient&#8217;</h1>\r\n\r\n		\r\n				\r\n		Growing demand for energy  \n According to the North American Electric Reliability Corporation (NERC), the demand for electricity in the US continues to grow, even while concerns over long term reliability of supply persist. The Energy Information Administration (EIA) predicts the country\'s electricity demand will grow at the rate of 1.8% to 1.9% percent per year till 2025. To keep pace with this increasing demand the US must add approximately 300,000 MWe of new capacity over the next 16 years. \n   \n  Exploring energy alternatives  \n As our dependence on energy continues to increase, the search for efficient alternatives remains prominent.  There are broadly two pressing needs that propel this search. The first, growing scarcity and cost of fossil fuel; the second, strong environmental concern due to increasing amount of green house gases being released into the atmosphere. \n Thus far green, energy-efficient technology seems to be the best answer to our energy needs. It reduces our dependence on expensive imported fossil fuel, reduces our carbon footprint and is gradually becoming cost effective. Energy-efficient green technology is making its presence felt in a number of ways - most prominent being the growing use of renewable energy like solar, wind, hydro and geothermal. A second method is using smart grid and other energy efficient infrastructure like energy efficient transformers. \n   \n  Could Wind energy be part of the answer?   \n Technological progress has enabled a ten-fold increase in the size of wind turbines, from 50 kW units to 5 MW, in 25 years and a cost reduction of more than 50% over the last 15 years. The U.S. Department of Energy\'s Wind and Water Power Program is now working with wind industry partners to develop clean, domestic, innovative wind energy technologies and aims to reach a target of meeting 20% of the nations energy needs from wind energy by 2030. With wind energy available in abundance, it is being widely seen as key suppliers to bridge the energy demand supply gap. \n   \n  Pacific Crest Transformers Edge  \n We at Pacific Crest Transformers have had a long term presence in the area of green, energy-efficient technology. Over the years we paved the way to energy-efficient transformers by developing and testing them first within our premises and then delivering them as quality solutions to clients. We introduced fundamental changes in the production of transformers and began manufacturing custom, energy efficient and environmentally friendly transformers even before legislations made it mandatory for companies to comply.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/aaeZeNjb2mE\" height=\"1\" width=\"1\"/>					</article>', '2', 'Green Technology is the new &#8216;Efficient&#8217;', null, null);
INSERT INTO `articles` VALUES ('46', 'Coping with Increasing Energy Demands in the US', null, '2014-12-12 21:11:38', '2014-12-12 21:11:38', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">Coping with Increasing Energy Demands in the US</h1>\r\n\r\n		\r\n				\r\n		According to Red Herring Inc., energy demands in the US are likely to surge by 32% in 2015. But even after being one of the highest energy consuming economies in the world, the US has come full circle. It is now one of the more aggressive nations in promoting alternative energy technologies. \nGrowing environmental concerns like Global Warming and the need for energy self-sufficiency has introduced in the minds of many US citizens a need to be more energy-efficient. The last few years have seen the launch of several energy-efficient electronic appliances and automobiles. \nThe US now plans to put in place infrastructure for harnessing and distributing alternate energy like solar, wind, hydro and thermal. A lot of investment - both government and private - is also being made towards this end, bringing down the cost of alternate energy. In the 1980s the average price of energy captured with photovoltaics was 95 cents per kilowatt-hour. With technological improvements and tax benefits, solar-electric modules have now become more cost-effective. In 2008, the price had dropped to around 20 cents per kilowatt-hour, according to the American Solar Energy Society. The US also currently has about 4.2 billion solar rooftops and as the popularity of solar energy increases, one can only expect the technology to become much more cost-effective. \nThe presence of wind energy in the US is also growing. According to the American Solar Energy Society, Wind power now competes with conventional energy at a price less than 4 cents per kilowatt-hour.  In 2008 the US had roughly 300 million wind turbines . So industry and consumers can expect cost reduction on this front too. \nThe US is not alone in adopting many of these measures, as they are no longer an option; they are an imperative for a sustainable future. To be sure, there are many more problems to solve  - for example, if 25% of the population switched to electric cars tomorrow, the demands on the power grid would be impossible to satisfy  and much thought and effort has to go into building the right infrastructure in a phased manner. Transformers, of course, will continue to play a crucial role in any power infrastructure. \nTransformers currently contribute to a sizable amount of the energy lost in transmission, prompting the US Department of Energy (DOE) to come up with regulations to ensure that old transformers are replaced with more energy-efficient ones. This has hiked the cost of medium-voltage, dry-type transformers almost 13%, but will decrease electrical losses by as much as 26%. \nIt is in this area of building energy-efficient transformers that PCT plays a prominent role. PCT has years of experience in manufacturing customized energy-efficient transformers - in some aspects PCT has also been ahead of legislation. Currently PCT is also gearing up to meet demands of the wind energy sector with its specially designed, robust grounding transformers. \nWhile the initial investment in energy-efficient transformers may seem high, so far it seems that utilities and industries are more than willing to invest in them, as the transformers pay for themselves very quickly over time.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/xI_IPiWYr4w\" height=\"1\" width=\"1\"/>					</article>', '2', 'Coping with Increasing Energy Demands in the US', null, null);
INSERT INTO `articles` VALUES ('47', 'Acceptance Testing and Maintenance of Power Transformer', null, '2014-12-12 21:11:41', '2014-12-12 21:11:41', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">Acceptance Testing and Maintenance of Power Transformer</h1>\r\n\r\n		\r\n				\r\n		An energy transformer is a rather critical piece of equipment and this makes its installation a monstrous task that needs to be well backed by a good testing and inspection program.  \n   \n Power transformer testing and inspection should ideally start with the installation of the transformer and continue throughout its life. The initial acceptance inspection, testing and start-up procedures are extremely critical. The inspections, both internal and external, will reveal any missing parts or items that were damaged in transit. It will also help you verify that the transformer is constructed exactly as specified. The acceptance tests will also reveal manufacturing defects if any and establish baseline data for future testing. \n   \n The start-up procedures should ensure that the transformer is properly connected, and that no latent deficiencies exist before the transformer is energized. Ensuring that the transformer starts off as it should is the best way to guarantee dependable operation throughout its service life. \n   \n Manufacturers recommend a wide range of acceptance and start-up procedures and it is best to follow them strictly. \n   \n  Power transformer maintenance  \n   \n A power transformer is a fairly reliable piece of electrical distribution equipment. With no moving parts, transformers requires minimal maintenance, and are capable of withstanding overloads, surges, faults, and in some cases even superficial physical damage. While transformers can withstand a lot of electrical fluctuations, they do deteriorate with age, and thus need constant monitoring to detect and correct problems before they escalate into expensive repairs. This is where a good inspection, testing and maintenance program comes in.   \n   \n Heat and moisture related contamination are the two greatest enemies of a transformer\'s operation. Heat breaks down transformer insulation and accelerates chemical reactions that take place when the oil is contaminated. One of the ways to address the heat problem in a transformer is to ensure the transformer is properly cooled, through regular cleaning of the cooling surface, maximizing ventilation, and monitoring load to ensure the transformer is not producing excess heat. \n   \n Contamination is detrimental to the transformer, both inside and out. Dirt and grease deposits severely limit the cooling abilities of radiators and tank surfaces.  \n   \n The oil in the transformer should be kept as pure as possible. Dirt and moisture will start chemical reactions in the oil that lower both its electrical strength and its cooling capacity. Contamination should be the primary concern any time the transformer is opened. Most transformer oil is contaminated to some degree before it leaves the refinery. It is important to determine how contaminated the oil is and how fast it is degenerating. Determining the degree of contamination is accomplished by sampling and analyzing the oil on a regular basis. \n   \n Although maintenance and work practices are designed to extend the transformer\'s life, it is inevitable that the transformer will eventually deteriorate to the point that it fails or must be replaced. Transformer testing allows this aging process to be quantified and tracked, to help predict replacement intervals and avoid sudden failure.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/iVszn6dme4k\" height=\"1\" width=\"1\"/>					</article>', '2', 'Acceptance Testing and Maintenance of Power Transformer', null, null);
INSERT INTO `articles` VALUES ('48', 'Going Beyond Wind and Solar Farms', null, '2014-12-12 21:11:44', '2014-12-12 21:11:44', '0', '0', '<article class=\"entry post clearfix\">\r\n		\r\n		<h1 class=\"main_title\">Going Beyond Wind and Solar Farms</h1>\r\n\r\n		\r\n				\r\n		Recent years have seen tremendous focus on renewable energy in the US. Emphasis has been on wind and solar energy and a lot of attention seems to have been concentrated on the desert areas of Southern California. With millions of acres of sandy area, the Mojave and Colorado deserts offer an ideal opportunity for huge wind and solar farms. Interestingly, the US government too has put its final stamp on a number of projects, many of them are being fast tracked, and California is now poised to become the solar energy capital of the world. But while a lot of attention is being laid on generating energy from renewable sources and much revenue is being funnelled towards it, is putting up solar and wind farms all it takes to reduce our dependence on fossil fuel, many would think not. \n   \n  Is the energy infrastructure ready for renewable energy?  \n Renewable energy generation seems to be only part of the issue, also of importance is the distribution and transmission infrastructure like transformers. The US has one of the largest energy production, transmission and distribution machineries in the world. Unfortunately, much of it is aging. The aging energy transmission, distribution network and aging transformers are causing reasonable energy waste; the energy distribution system also needs to be upgraded to take on the additional task of dealing with variance in energy from fossil fuel to renewable. \n  \nUndoubtedly, renewable energy from solar and wind have the potential to power millions of homes across the United States. Though initially capital intensive, renewable energy has the propensity to pay for itself in a matter of years, reduce the country\'s carbon footprint and dependence on foreign oil, however, before we begin tapping into the benefits of  renewable energy we need to have infrastructure in place that stores, distributes and transmits energy efficiently. \n   \n  Problems associated with renewable energy  \n One of the biggest drawbacks of renewable energy is its fluctuating supply. This problem can only be resolved by putting up storage units for renewable energy and storing it when it is being generated plentifully and used even when supply is low. Huge storage batteries seem to be the ideal solution. \n  \nThe smart gird is yet another aspect of the infrastructure that needs to be responsive and \'smart\' enough to address issues caused by fluctuating energy levels, track energy distribution and pre-empt energy disruption. The biggest issue however presents itself in the form of energy transformers. Energy transformers play a vital role at every step of the way, from collecting energy at solar and wind farms, to stepping it up for transmission and then stepping energy down at multiple levels for consumption. \n  \nThousands of energy transformers in the United States are rapidly aging, they need to be replaced by energy efficient distribution transformers that are hardy and able to transmit energy generated by both fossil fuel and renewable sources. \n   \n  Pacific Crest Transformers is ready for renewable energy  \n Pacific Crest Transformers is doing pioneering work in manufacturing a range of energy efficient distribution transformers for the renewable energy sector, especially wind farms. We have designed and custom-built Wind Turbine Step-Up Transformer to increase efficiencies in the renewable energy market. Our transformers are built with a cruciform core, robust winding, clamping structures, seals and gaskets, and have in-built protective measures to prevent hot spots and partial discharges, so that your transformer has a long life. \n  \nMuch like rectifier transformers, Wind Turbine Step-Up Transformers are designed for harmonics, additional loading, and have electrostatic shields to prevent transfer of harmonic frequencies between the primary and secondary windings. \n  \nSo while the emphasis is currently on producing renewable energy, it\'s time to seriously consider the capabilities of our transformers to adapt to our changing energy needs.<img src=\"http://feeds.feedburner.com/~r/PacificCrestTransformers/~4/n8q9jF_TdbE\" height=\"1\" width=\"1\"/>					</article>', '2', 'Going Beyond Wind and Solar Farms', null, null);

-- ----------------------------
-- Table structure for basicinfoes
-- ----------------------------
DROP TABLE IF EXISTS `basicinfoes`;
CREATE TABLE `basicinfoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Value` longtext,
  `Key` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of basicinfoes
-- ----------------------------
INSERT INTO `basicinfoes` VALUES ('1', 'value ', 'test');

-- ----------------------------
-- Table structure for contenttypes
-- ----------------------------
DROP TABLE IF EXISTS `contenttypes`;
CREATE TABLE `contenttypes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(64) DEFAULT NULL,
  `Description` varchar(128) DEFAULT NULL,
  `PrentId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of contenttypes
-- ----------------------------
INSERT INTO `contenttypes` VALUES ('1', '技术文章', '公司技术信息解说', '0');
INSERT INTO `contenttypes` VALUES ('2', '行业新闻', '同行业的新闻', '0');
INSERT INTO `contenttypes` VALUES ('3', '公司新闻', '公司的最新新闻冬天', '0');

-- ----------------------------
-- Table structure for contracts
-- ----------------------------
DROP TABLE IF EXISTS `contracts`;
CREATE TABLE `contracts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(256) DEFAULT NULL,
  `CustomerId` int(11) NOT NULL,
  `Prepayments` decimal(18,2) NOT NULL,
  `Status` int(11) NOT NULL,
  `CreateTime` datetime NOT NULL,
  `SignedTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CustomerId` (`CustomerId`) USING HASH,
  CONSTRAINT `FK_Contracts_Customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of contracts
-- ----------------------------

-- ----------------------------
-- Table structure for customers
-- ----------------------------
DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Number` int(11) NOT NULL,
  `IPAddress` varchar(32) DEFAULT NULL,
  `CreateTime` datetime NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of customers
-- ----------------------------
INSERT INTO `customers` VALUES ('1', '123456', '192.168.1.123', '2014-12-12 21:43:13', '1');

-- ----------------------------
-- Table structure for feedbacks
-- ----------------------------
DROP TABLE IF EXISTS `feedbacks`;
CREATE TABLE `feedbacks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Content` varchar(1024) DEFAULT NULL,
  `FeedbackType` int(11) NOT NULL,
  `CustomerId` int(11) NOT NULL,
  `Mobile` varchar(32) DEFAULT NULL,
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CustomerId` (`CustomerId`) USING HASH,
  CONSTRAINT `FK_Feedbacks_Customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of feedbacks
-- ----------------------------
INSERT INTO `feedbacks` VALUES ('1', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '2', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('2', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '2', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('3', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '1', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('4', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '1', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('5', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '1', '1', '12345678932', '2014-12-12 21:42:49');

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) DEFAULT NULL,
  `ImageUrl` varchar(1024) DEFAULT NULL,
  `ThumbnailUrl` varchar(1024) DEFAULT NULL,
  `Description` longtext,
  `ProductTypeId` int(11) NOT NULL,
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductTypeId` (`ProductTypeId`) USING HASH,
  CONSTRAINT `FK_Products_ProductTypes_ProductTypeId` FOREIGN KEY (`ProductTypeId`) REFERENCES `producttypes` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of products
-- ----------------------------

-- ----------------------------
-- Table structure for producttypes
-- ----------------------------
DROP TABLE IF EXISTS `producttypes`;
CREATE TABLE `producttypes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TypeName` varchar(100) DEFAULT NULL,
  `ParentId` int(11) NOT NULL,
  `CreateUser` varchar(32) DEFAULT NULL,
  `CreateDateTime` datetime NOT NULL,
  `Level` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of producttypes
-- ----------------------------

-- ----------------------------
-- Table structure for recruitments
-- ----------------------------
DROP TABLE IF EXISTS `recruitments`;
CREATE TABLE `recruitments` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) DEFAULT NULL,
  `Description` longtext,
  `Requirement` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of recruitments
-- ----------------------------

-- ----------------------------
-- Table structure for userinfoes
-- ----------------------------
DROP TABLE IF EXISTS `userinfoes`;
CREATE TABLE `userinfoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(32) DEFAULT NULL,
  `Email` varchar(64) DEFAULT NULL,
  `Password` varchar(64) DEFAULT NULL,
  `CreateDateTime` datetime NOT NULL,
  `LastLoginDateTime` datetime NOT NULL,
  `Mobile` varchar(64) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `LoginErrorCount` int(11) NOT NULL,
  `AuthorityUrl` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userinfoes
-- ----------------------------
INSERT INTO `userinfoes` VALUES ('117', 'Jason', 'Jason@mail.com', 'E10ADC3949BA59ABBE56E057F20F883E', '2014-11-23 20:15:33', '2014-12-12 21:00:10', '12345678901', '0', '0', '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17');
INSERT INTO `userinfoes` VALUES ('118', 'test', 'test@163.com', 'E10ADC3949BA59ABBE56E057F20F883E', '2014-12-07 20:19:47', '0001-01-01 00:00:00', '12345645645', '0', '0', null);

-- ----------------------------
-- Table structure for visitlogs
-- ----------------------------
DROP TABLE IF EXISTS `visitlogs`;
CREATE TABLE `visitlogs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IpAddress` varchar(128) DEFAULT NULL,
  `VisitorName` varchar(64) DEFAULT NULL,
  `IsSendToMail` tinyint(1) NOT NULL,
  `IsSendToSms` tinyint(1) NOT NULL,
  `MailTo` varchar(512) DEFAULT NULL,
  `SmsTo` varchar(512) DEFAULT NULL,
  `VisitorMail` varchar(256) DEFAULT NULL,
  `VisitorPhone` varchar(256) DEFAULT NULL,
  `Message` longtext,
  `ProductId` int(11) NOT NULL,
  `VisitDateTime` datetime NOT NULL,
  `Country` longtext,
  `Area` longtext,
  `Province` longtext,
  `City` longtext,
  `District` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductId` (`ProductId`) USING HASH,
  CONSTRAINT `FK_VisitLogs_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of visitlogs
-- ----------------------------

-- ----------------------------
-- Table structure for __migrationhistory
-- ----------------------------
DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of __migrationhistory
-- ----------------------------
INSERT INTO `__migrationhistory` VALUES ('201412071154295_AutomaticMigration', 'ZdtbSite.Core.Migrations.Configuration', 0x1F8B0800000000000400ED5DDB6E1CB9117D0F907F18CC63E0D54872D6D818D22EBC921D08B12CC5236F82BC185437356A6C5F66FBE24808F26579C827E517427693CD3B9BEC61CF8C04C180A1E1E514592C168B97AEFADF7FFE7BF2D34396CEBEC1B24A8AFC747E7470389FC13C2AE2245F9DCE9BFAEEBB1FE63FFDF8FBDF9DBC8FB387D92FB4DC6B5C0ED5CCABD3F97D5DAFDF2E1655740F33501D644954165571571F4445B60071B1383E3CFCD3E2E8680111C41C61CD66279F9BBC4E32D8FE403FCF8A3C82EBBA01E96511C3B422E92867D9A2CE3E810C566B10C1D3F93FE2FA7699D4F0E0AC28E1C1457E5782AA2E9BA86E4A389FBD4B1380DAB484E9DD7C06F2BCA8418D5AFCF64B05977559E4ABE51A2580F4E6710D51B93B905690F4E42D2BEEDAA9C363DCA905AB48A1A2A6AA8BCC13F0E835E1D242AE3E8AD7F39E8B888FEF11BFEB47DCEB9697A7F3777196E497306FE63399DADBB3B4C425395EB7C372D0D7793513735EF592810408FF7B353B6B523C22A7396CEA12A012D7CD6D9A447F818F37C5AF303FCD9B34E55B88DA88F2840494745D166B58D68F9FE11D69F7453C9F2DC47A0BB9625F8DABD375E822AF5F1FCF679F1071709BC25E00B8CE2F6B24577F86392C410DE36B50D7B0CC31066C59A85097685D8312151CA66847C1FF530424B76832CE6797E0E123CC57F5FDE9FCCD1FE7B30FC9038C690201FD922768EAA23A68420CD2F852A65393781775D23B2D15A43DD0D44E53584E4DE93CA9A2120EF4E9FBA3E300A42E222B91D7FE344E164C09D855435927510A7D144357E3452D1869DD24756A9BD16184A66566756F9D0847C73F84A4748ED87193306DC57E7BAABC2FEB18550D067751912652A49F8B228520F706BA2A9355921309AF3056CF5C64641CE8B23D2960FD85A4C83266E8CF407A12D1B97984EB4DD7A71BB0B234F7F8FB37213460B6B22F514787C72194FACD7D93DDE62049A7A1F6097C4B56AD0E310D071699CF306DCB54F7C99A481697FF95CA176A4059649F8B54ACDFE77FBD01E50A62512A2C8596455346635707A1D9CE2B0457EB659530D2DA86D9770E910D93AC078C9840ABC4285BD83863D82C08355DE84CB04E173AA7464D979F41954468975A784C96BECECB5431D2FA05A48D6DAE845932518F03D3F0D2B325886A4F258BABBC888D91D6901D1EC674396B470C969B9A59487FAEC16386BA56F506318C920C204305E5450939B543BA7A19010CEB4F638918DB54824D4BE58866F9DAB3250C65C52F93550EE3715066C38B8C8E7119C17DFFCA4A896B8890A95D40C4121BAD1EAC11EE4A8054795102465A9F90C1CFF6C8E3A6E6C5F5BB382E6155853DA49974369D150DDB66BA74DB594E3F4018DF82E8570F39A5555EE4D4325E43070381B6C0742C94D30D31C357DC02AD8297C56D625DB4773ECFC62D3594B9DAA546C954961AB5C4464B0D6A79DC78999BA4C6CB0436D21AD8CF87D9645F6460059FC349D9A8838A30FB3C22CA98CAA6DA6A123DC2B54FAB4AB8FCAFE46FE1F04397AF9C156A0BE9CE0A6D2DFD05ED49EA8FC54A7F484373BFBE7F58A7686AE9DA6A2AA3B4D75870A3F34D81D5BEBAF0E57CD3AE40109D219D787818623E07B985EFA6F297CA7A9F16D0F80876F9F5117E83A967DF87748F7E428F523CB22563D54EA32631550D1E3398567999BE665AEBE13D6F189BA61D8CA2DCC67DC845B584797C535C22BB66D3BB628AB5CCAA4DA170736E8AC95F0CA0966E810A194E9EC5939DBD125AD7F7453EFD41EF259A0CC8FADE967DBAE982D6F266FC2A635C22146B2EB4E927AF188336E2A855E3338CCA26A9B3F6CCC579E1E06ABDAC1D465A5BD90A6F73CBF819FED62425CCC2BFDC7196576C997A5E2DD32A2F926AA485593420AD416CFEF7997D390C62DD5C83AAFA6751C653D309BD81011556EF491E0C71F010399031899F3C7F839B5A7F6DDFDF9765517ADFD9A860EF9AFABE2891E4DB8FEDC2AAAA26E31495EE91E445F521052BF60D86B30A53C1422933D4D31896E923E20CCF6F91B997105F1E928EFD0DDECE67ED5394D3F9A1320E42D1EE1881943D52D9D831CCC244F9567E340345A0DD31EF535177F7FBAE2C944A8F61A278A1359A853CCCEE18F8D706569DADA3E7885CBEDFAD90E2C72E0C7C57554594B4EC505F80B2977622D9F7793C73797627BE39E99F955E227E256BC421A45A70AF64A3E22A3F8729ACE1ACFBC00451015504625513A21EC55E2DEBCF9859CBFACF21C456FD4121864C1C888F1D139022EC0A8D7492D7AA3D94E451B206A9037FA4BA8ED614EE764F45CE39876B986343C881092EE4A537E56A4B7A82D2C00C31EB64C109DEB03C8A4F766C436E78BFA3BE7E1A1E701BB04690D835EF84F23D5A08B5CDDF92046AC7C449FCB827063B913DF50EDF2422960B7DF5BD858FEC99DF013C09D933367F0BB2671C9327217BDABB179394D82F6298A008D79F5B5987ED77D34ACB265A876DFCD98224DA98E0425E7AC0B01379349EF09A467EF8B8978D3EBBD173D78CC32F0906A56BF7FA71A8135B10CEA171F210D02D0967772A814D0B54A3DFFF9C831AB406EB83EE7C1F6DD0C976AF22471DB25C61CC25ACE9B10AF58680F6E2EC14846E1A987B05453C2598FE5B251584EE3C062038235E07236CAD06A0FA4F8F7440DCB74C0E2DC2469DA9399D7D3D044216582D486FCF0C80D0255E07C2ACAD01107657A560F47AC30DC23446C2B23B00C53DB15270989A1C00E16EAD7438C255D80014BD53D0E1B02B0A09849BB85A41E6BEE1E38ADABEF593B58AE31944DF1B791E296ACAF1E88003647D90D706B1FB8EAC91BE4BD1F3C5B21376DC0B4B1C21F378801DFADD2F0FC566F3C6CCD0BC9C569931B03573DC9C713DE054898519E6EDD844CCD03FC152F931BC5D70DF30705D11159B8531563B5F050CC11AF39B03953D6ED6AB9FFDCAF58A53DA161E0D5AAC9BF1895ED7F486519F77B2E83C6D91849385C125D7C92558AF937CC5B9E82229B365E79FEBECBBA5BFBBAAACC3584402BB6533AEA754172558412917EBA1187E48CA0A3F7101B7009FE89FC599528C37030D2B1BA5A4587AEAD0D1058F56A16F5CED9ECA380351B59E09D407D449BC00B7FD85FCB262AE3BC32ED3400A4ACD05FA599136596EDE11986BB3E7B43C064B7547EA2ED679942EC51DA1BDC4E401DA04F7FAD427150F41D3DC51789F533C129FEE8EC6FB95E2D1F87477B4CE759430DA911EE16421899AB23353E45BD9E38A33C66D3E994DB6B1B389EC9446CC2553CD696612F9FE9C0720491EB391797912A6234B1E81C51E56683159B6C74C953C3A099356CAF3906EE6D849180696EC8EA57B97C083EAF2FD7444BB7F9215846653E58043EFD83468A6EB378B1C62074E82140265CF681D05E29C49180292E6D10AE18332A13942CEDE682E6187184C7BF10734FE1ACC5A7B1A2DB6F92A2EBCD414963C3EC3438F690D14B37DB223F9E18ED782490F3B95F3971D4BDD692487B8EDE10148923B46EB9487476813F6668CD999495005D11E998ED30EFAAAFB6BE0F037ABC26A67B97135A3094E7424F5C032DCF1E8FB3B1E8AA679F491FB4C58E82397EED126CE4F8ED02E2E7D7F26487FF8156E82188EF85C2688B1EA446B27713E23AC9E24CDC3FE62EE6784A6B0E45D892279B02C5AA98DDEE2DD9100B283DC6002D85F25F90BA0B9EA3402186A5B223EA5E5C1C49C5DE97DFAE29F47A269534F8E1D09B6E5CC7AA45CD3EB4D7FB136D6DCD72D09F3A3226E6A69EA36B6B5DBDB2E09CF8544ABC8FA92C88CF914674AE08D3C7F8B3F7AC66C73234FFB2549699FBA8B2B02DEEB862A475DBA2F9AFE1052CE7347250E36783092B43712CE2E1C838977FFB8C45FB6CD55A7116CCE558500B21E611F0BCE2884930B3EC3E7049BF738211E62F339FE88ADDF091D609BE1613A11E71382E944D23C36A59D6F09613FDA2579F35E659590E18D47BC436800498E07AFE8475502B368A2F7926C588E3D4FD9443F0F4A376D2A6F47EA4A788F164C63F1CFD8FC9596B5F6BE9AB1A14D45C1CF018F2764EC8D1CB1C788C184A87FC3E82F41E6AAD3880FF35D205CB6F6A9EE48C43B010F43927C6C42EA7C40B40969EACEAD38D5CB8060D1A9D9DB3E7D60FE04C4559DA67AF455F62820F454CEF4784E233817101ED508395B5610CA4B37B9484F9DA4F4BFFB976EE495D970444AE5D9595704BBE82FBE25317E7276F9B8FC2D3DC0F907ED9F6769D2AA4D5AE212E4C91DACEAEE73F0F9F7076FA45096FB1356725155B1E0F7C5165B521CB02DB887493057071DC0F8866190BC49B6443688E8987F0365740F4AC5FF08C3F40CE01808518CD71808540DCF1808588DC6A8056E5DD8F921F3C117B598AF0720BD632D3E8F8972C347570935184A50432D70EB406C24B0EC64083F4DABDBDF5C9095C340110D03812BF10D6F8B220D18DC708C8E93E215A4051A9AF65B3B7F8501E5388589D627DF451EC387D3F9BFDA9A6F67177FFF2A547E35BB2AD1EAFA767638FBF726310EB512D77A90F4D42B424843BD1CB7CED3FD60757ED947828F0A03F83C94D7042BB4C61F6130E5E56B928C8858F73CC65588143756277181E0DC20FCE3BC3D0F6E0F9B0023F4A61A49C67939E86B6EB4166802B1C5D306621BB5FE2AA12702191B6A18B651C0FE61CF9EC79C10E38D8D195925DAD8A85DC9162546705B197071D23F967AB2922159CCC12C425D40AF511A65D78A5774DBBA5F52EF1D5AEB79C8ECA09D3CC29A956358EDE3D6C8C9BC1F6B5F4AAFAEFCE69A5079A3E9B6A399F18C7691ECED9455D80EBD0524C019B41ACF28A8429DE8A44B086614D094D03F497AB282A704E709A59B35B178021D8FE842EF8C3AC6D4C4DD19852306DD0975802DC4D80905AA09A9136AB7AD8BA0130A5B0A98B3E172397AA9DC7099D4C6D19976A534BE457AB20A6B0A3B32A045A689EF12F8E44FFF38E8C98EA71C3725906D21844909B4F0C8515142DD744F6A069942A204C277D8698F59E1C57828A356654330943116B02E14CA66B33A5C78841D8743E89D8D72ADD85AE8836D78B135FB0852493DB1B006BD17445E82B6E1F15DF501393294C23801327FF51D5C7A2C2E1834E2B36BD7F0EE6109F64176981F5EAE0DEEA110F65E762C1F87EFA1EC5C0FFA09D53BF5DC8F3002BB0919B0C51001CF371C80C7084E2443CC7B36D704F7C8039B48D136FDF83F1987FDAA435779E4444FE49CD77D66ADAB1EF9BBF7F968E7748B8FE53A8B9FF7E6BF18A042AD629506CDD151002667E032BE60FB2B34845C1D1D9B1773B3BF7FBBBB7F1D9D3EDBB14B9D21A8ED4F9765EA8CD601B9315A803558809684D117B74C8299240A0996A52361F41C6E0A13600B34A023D0EB56477C836C09B9163A6EB2C514A7428865E9A8187D65DBA2180C0531D0111283200CD062A10C14422C4B4785E66A58B6A32808A6A8071A55AF3920E0EA9A2294EC437C03491F88CEBE6C1D959595E8476FF3AE068F5E30BEABB246131D526DDE55ED5E22686C02532C026BB7252D2BF82BDABCD313471DF068BCC1B8E52A1AE3C5040922A07E42894CC426C7A7D5DDAF7358E1A7A514E20461E630128CC3BE0C56A1D44C955A448B28978D358891E588B5D41D9ABB283B8255D506BE262170DF67B730BEC8AF9A7ADDD4A8CB30BB4D0567A2D8D6B5D16F2325886D3EB96A2FA0AA105D40CD4CF001FF55FE7393A42CF6F107CD55A201021BD1E49A078F658DAF7B568F3DD227C5DF850988B0AFB7FD6F60B64E115875952F013EE3F76F1B5A1A3FC215881EAFC987B06690E18110D97E729E805509B28A60B0FAE82792E1387BF8F1FFE07A6BBB01AF0000, '6.1.1-30610');
INSERT INTO `__migrationhistory` VALUES ('201412091519405_AutomaticMigration', 'ZdtbSite.Core.Migrations.Configuration', 0x1F8B0800000000000400ED1D6B6FDCB8F17B81FE87C57E2C725EDBE905D7C0BE43E24761348EDDAC9316FD62D012BD164E8F3D3D521B457F593FF427F52F94922891C3974489DA5D1BC60187981467C8E17038339C9DF9DF7FFE7BF4CB6314CEBEE3340B92F8787EB0B73F9FE1D84BFC205E1DCF8BFCFE879FE6BFFCFCFBDF1D9DF9D1E3EC5BF3DDDBF23B3232CE8EE70F79BE7EBF5864DE038E50B617055E9A64C97DBEE725D102F9C9E2707FFF4F8B8383052620E604D66C76F4A588F320C2D51FE4CF9324F6F03A2F507899F838CC683BE9595650679F5184B335F2F0F1FC1F7E7EB70C72BC7792A478EF22BE4F5196A7859717299ECF3E840122735AE2F07E3E43719CE42827337EFF35C3CB3C4DE2D5724D1A5078F3B4C6E4BB7B146698AEE43DFBBCEFA2F60FCB452DD8C006945764791259023C784BA9B410870FA2F5BCA522A1E319A177FE54AEBAA2E5F1FC831F05F1258E8BF94CC4F6FE244CCB2F395A57DBB2D78E7933833D6F5ACE200C54FEF766765284E58E1CC7B8C85344BEB82EEEC2C0FB0B7EBA497EC5F1715C84213F433247D2071A48D3759AAC719A3F7DC1F774DE17FE7CB680E316E2C0761837A65ED0459CBF3D9CCF3E13E4E82EC42D03708B5FE684AFFE8C639CA21CFBD728CF711A973070454209BB80EB1AA5E4C36E8C6628E5FF1B08846FC9619CCF2ED1E3271CAFF287E3F9BB3FCE67E7C123F69B060AF46B1C90A34BC69003D189E36B1A4E8DE2835773EFB45888F420473B0C713A35A6D320F352DCB1A61F0F0E1DA0BAF08C48DEDAE3385A302160160D691E7821B6110CF58857B1A0C57513E4A1E944BB619A8A98D983F1201C1CFEE412D32921C74DC0A415FBDB52E47D5DFB64A8337017199D6203E963928418C5D680AED26015C494C3B312564B5CA264ECA9BA2D3194F28B709161CFC83F1DC94982E7E609AFC7DE4F37686598EEE18FEF5C48C06865BEA20EF60F5D08F59B8722BA8B51104E83ED33FA1EAC2A19A2DB8E9265BEE0B0FA267B08D694B3B8FEDB86BFC804D224FA9284707CDB7F7B83D2152E5929317CB44C8AD41B7A3B8069F7BE21B851AFB78416D726D4BE534C749860DDA1C438BA2506E9C2DA13C34E81ABE3D29C04E37169CED4A0E3F211658147ACD4C4E2B0B4635E8F8A16D7371416A6B3E2E6CA242B768CC34ACEA6C8CB2D856C39E4956DB4B8BAF47037AACB49B563381DAB6611F9B9464F11595AD62AC4D80B22441415D2E705D46B4764F5D24325587B1C4B42D822033A6DC3474D97AD3E9B62575AFC3258C5D81F064AAF78D1DDD15E23E5DA6FD957F00E019DCA0B047E31EAF66093E82F04E8905721A0C5F59928FCCC461E76342FAE3FF87E8AB3CCAD9366D2D3749214CCCCECB3ECDE7C7A8EB17F87BC5F2DF8B419F2CAA786FDEA720C3832819BBD90BC1BB0C396DD1CDD8297C95D60BCB4B77ECE865D350D7195578DD4295D35F217A3AE1A3273BFB05237E988D703ACC5D561CFBB31B22F22B4C22FC15336C851E1C6CEA3AC5C62192BAD269123DCFC94A284EBBFA5FF06CE0F55BFE42B547EA4F2159A66FA8DD824F9A764A576D234BDB7678FEB901C2DD55C75DF48F3D57E38CABF09486D2B0B5FFD9B660142F074C9C4FD7D17E7D9C92B7C7D94BF66C6F73487CA87B3C7AF4FF83B0E2DD7DE257BD4077A90E0113519A3741A74881BD16071829B21AFC7578F6BDD6DF3BAD169AACD48D24DBC875C644B1CFB37C925D16BC6BE1537B09651361654399D9B64F2880132D30D60A1DBC9937832DF2BC575FD90C4D33B7A2FC96120DAF7A6F4D3B1175A451B67B74CE54E4A5D3F9028A2C8C8E5B8090A7F0F626FFAAD3CA904EDC4484E838C80F6268829D1AA099246EF5AFD17B5864E3B6190E6F0057B6911E451E577EBAD3C70A35EF5072DAE8DB84336E936F8827F2B821447EEA3B77AF36B699D58861734435E39558BAB245107B73AB1FBCE22B34AE444C3BD4659F6CF24F5A7C6E3DA88455929DE83D819C4CE870447064519F6FE1D8FB500AAB59FA569925ABFDB2974A8227F4852C2F966D7AD5B5155449CA05205CA5E64E7215AB1DFE1F41661323057C28CACD4C769F84428C3D31B12F712970FC874617FC377F359158E743CDF97F6017C5ABB92E8B70732196B8219882846660C262004B43DE27D4EF23AC6A32F0985AF8710113E6A0E26210F667B04FC6B81B35AD7515344FCBEB558E9E7877D08F821CB122FA8C8214701B3684B88F62CF6677D422F61DC511B5A7C49E815AC098588682957252A1557F1290E718E67F58F8C08169479C897252159916F35B3F69D81CDACFD490C9CD51F246444C5C1A5EB394021814D8C3014C4B9AC0F114B3358A3B0077D84B13DB5A972D92D16B1E714AF715C2A423D88D007BDF0BB0279262D426163BA8875B4E018AF9B1F61D89669CB35315C72045CF7869B002B18893DF54FC8DF83995039FD0D71A0724F7AB11F1766B215DE93E338742C6208EA90636E6C784F1F0BF22C784F3BFD0DF09E764F9E05EF29DFDF745C627E8C638C029EC037720F9BE313A4994D740F9BE8B3014E3411A10F7A2188652BFCA8F5F0EA76BEDBDDCB769FBDEAF6978CDDD1249DDCB57DF9D8B5880D3067D73E5930E88698B3F64A94AA0519D1DA3FA7284795C2FAA8F2EF13039D9A7B197575887C55C25CE2BC71AB341931882DCEBC208DD1C0526C48EC2980697FAF2603692C8F0E109C12AF02034CAB0E50EDCFCF5480B8DFB3F59851A9D4E9A653EBD75D40E805AB04D2EA331D409A2B5E0584695B1D40D85B9504A3951BFD40E8F6085CBB1DA0B8303B090E13931D40B8572B151CF014D601AA795350C1614F140210EEE02A1999FB1D27F7A9E9F79EA254E9E9836857239E23494CF5741D7000D91AC4BB012EBF276984DF26A9E962B0847BDAC20245E839EE2087DAFAE541B1D33C9A188AE87999181DA6594FE38C5B01274A0CC4D09B631311431D8627D3A3DB5CE86F30704B8182CD4018A39E2F0374411A7DCC814C9E7EDAAB9DFECAAD8A13DA061A756AACE3E8D43CD7B48A51DB77B4A8B3ADD186A385262DDBD1255AAF8378C5A569A32DB3659DA3EDE487A57DCAB2A886B1F000B94535AEC59427295A61A1B794433E3E0FD2AC0C734277A8F4E89FF891F419AF066A6EB60693A4E9C95BD75C78CD9026CED99CAD8E531065ED99823A278B2C2FE06ABD98BF56F4636765DA3C14A254F1807E92844514EB2D02FD681652CDC360ADFD21D50FEB3C94BAA53F84EA1193075035F41FDFE425E341346DFDA1F079C778487C7B7F687C6E311E1ADFDE1F5A9D3E0CECB6A78670B410584DB2CC24FE966C5C7862FA9D27BDCA36F434514B69C059D28D9CE624D11C043C00DA64711A59A62F701C59F300582CB0420993755B9C5421AB1738B4429F0577B3E45E601B58737F58AAB8041EA8AADF4E4654F69328201446550F38CD1B9B029AEEF9CDC08765122FC08548B2198DBB401374812DA06D16B3003F2A04D3013D3B23B98085E84C7AF10E1A7B09661C3D8D141B7F8B83484D70E5F11D16724CA9A0E8F5932DF10FE75E73C63DCC2B67CF3B86B1D3700E4DDDC403A04DFD61548999780855C3CEEC31F39938151095CB749874500FDD5D05877F5905B79DE1C5550F0D245212C403EBE80FAF89BFE341356D166BE47E2A0ED6C8B55BCC89CB9504E6C5B5EFCE01699D5FEE0E88C6C5D7E78068874E7477D20444E0F6A46D16FA174B4104A6C29AB7C58A3460196AA9855AE3DD12033247AE33066C9F92EC19503F741A06746596C0505A1E18ECD996DC6F22FE79484DDBD487634B8C6DF0590FE4EBE679D39EADB52377D52461B974A051DBB46EC2ACDD9CB904C285A056648C24D2C37C8E27C5B121CFBFE20F3E319B34E49B75095CDAB66EE38980CFBC22F351DD6E0B4DED8414FBFA43A549567860B46967389C3D383A63EF36B8C49EB7F543A7616C2E5D0900B21EA01F838424C073C177D878B0F9AC23D089CDF7D843AC728FA800561D16AA134D40025427DA666194D6F945803D5A3759D35E2615E8B0864733842800D21E0B5A353FAA02C46A1AADAF64CD756CE96583B93EA4650E11796DC60FC9B24B95DE37EDFB6B95D103BCBE562D5694A2E93A0442D1568B35553F07070B52FC40DC048125DB10DE6D69EBCE5C0720DECFD98DC08709DA5F0AC6D1BB6A26B856C5411E091E1EE8D8193E62C19ECE98A88D11B5E720FDD069D887E586008FD96D6B7F4834FB030F8636D9E8DC4D7207A87337AD5BD792E52C0E406396BB37EDDD61F91AA0D6D4B45AAC55CCD800562A765A5C97207903B83641CF8605841449287ED262A72DEDDF6D24218DE2EBAEFA2A85F5D59F946530C895EF97217D974FCBDFC2BDB27FAFFAE749185462B3F9E212C5C13DCEF2FAE7F6F31FF7DE09E56277A774EB22CB7C9057C754BF156ED806D2EF0425553B13ECD8963A1132B6564846544D8DBFA3D47B40A994DF85C1B42C92EA0822AC89EA08A85C02D51160B9E2A912709526D20E325FE05409F36D0748EB7AA62FE3A0DCF0158C5C6D8654385409B84AD03610B098C4A90CFDCBABBFB94246FB8EAA863A022ED510BD4B92D06101D121324EA8091226646BAADF32DA0B0C2CD6020D94390F2F621F3F1ECFFF558D7C3FBBF8FB2D18FC66769592DBF5FD6C7FF6EF317544951C576569B5942BA06CA89A8FAB0205766055B50F06021F546AF36508AF096E6845BE4767C2CB5625195015F265EC2BA8C638542671C516FB81B0AFA5F832A8DDAD020C909B72B5A6DED7413B72D45DA02876E84F5BEC70D0FD2B957771A46CC8A50E0701B62F2DF832CE04ACE9376467A58A7E83AC920D720C480BEAF0725207A33D5BCE103466671AA1AA68DE2089B26DC10BD3E2EE16D75B97AF7B193CDBA9270FD066C53A71BB681AF552EF87EA9742549BDD590383471DB72D9D8C176445B2D83423B3ED5B3388031FB45C33CCA9409DC8D3050A86395425D4215FCF96F1A40258AE64B3A2DE9523F788AABCD52037A6A2B6D52038B0B0952B0736A863E50AA8A26C952B6B5B55A5CA156CA128D5C8EB72F05539F29A54D6AA726939A596DE26C5531E57986A049541DDA9C10EFD201FBD1EB16A94632F9C36D4EBD9DE0753A8E90E155E457922C75BAA8EBD7AB6FB2996FD71A4BA812A3F8EEE75B1A88FAB408249B54C5D451F47F07B3832862850B09CCF20A54753CB678881A1AAE433EE54BBABEEB1E56A1E6DAE5C6E161BABDCB18924CCFA145732AA675695A34DE2C973D0260A16C8294C07560219C640FAA405CEB9C7904144C13EDBAE6CD0BFAAC62EF00E4B23CDCDA17F258F9DE71D436E831DE49DEBCE34B7EA9CB4BB5105633B152F3658E1E2E556B3B0D8C1897888257FE7A6D0BF70C6182EDA64198A67536F42CE472CEE1C4CA4CF158D60DABA5C50A2FEF903B19CEE4AAF67ADF1F3C528161D581AAD58C6D1F4A830205D2E7B113ED0FD251CA05785C794845F5FAEC25CAD4285A7EDEEB9A45A1154AEA7EED22D46993F5F5BECC258EB4289429B4A5E44C154120905EB52A1D026BED755B930D5C9502168656B4FF81ADE02BD063CFD788B094E0911EB5261D1A67A3715E1E8AAC1A142046B7874E06295382444AC4B85A5E955906C4B453C74453B14A25EE120E0C6EA0AECEC42790E411EC05C75A6858AC20AA6811CBF54E7C537862F559468309FDAF8A52A6D09A7A53574A5348CCB16A42C48B7357ED11317CDB098BC46B9E5066ACB1D39A98121FF4295A888455C7AABEBBF4E715646EE36208E08CC187B40396CBF294568A3A60A336A3E91DE7273E413CDB19452F7E4EC926E0F675955B79D56703E8BEEB07F115F15F9BAC8C99271741782FC15A5AE6BC25F15FA80733EBAAA1EA032174B20D30C4A07FF55FCB1084256BAFB5C1157A201512AD1F499A7DCCBBC7CEE593DB5903E4BE95A748028F95ADDFF0647EB9000CBAEE2252A7DFCF6732357E327BC42DED335FD9DB11E48F74640B21F9D066895A228A330D878F227E1613F7AFCF9FF75CF03F1C4B30000, '6.1.1-30610');
