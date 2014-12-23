﻿/*
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
-- Records of contenttypes
-- ----------------------------
INSERT INTO `contenttypes` VALUES ('1', '技术文章', '公司技术信息解说', '0');
INSERT INTO `contenttypes` VALUES ('2', '行业新闻', '同行业的新闻', '0');
INSERT INTO `contenttypes` VALUES ('3', '公司新闻', '公司的最新新闻冬天', '0');

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
-- Records of basicinfoes
-- ----------------------------
INSERT INTO `basicinfoes` VALUES ('1', 'leixiangyang@foxmail.com', 'mailUser');
INSERT INTO `basicinfoes` VALUES ('2', 'woshuo023.', 'mailPwd');
INSERT INTO `basicinfoes` VALUES ('3', 'smtp.qq.com', 'mailServer');
INSERT INTO `basicinfoes` VALUES ('4', '25', 'mailPort');
INSERT INTO `basicinfoes` VALUES ('5', 'xxxx有限公司', 'companyName');
INSERT INTO `basicinfoes` VALUES ('6', '020-12341234', 'companyPhone');
INSERT INTO `basicinfoes` VALUES ('7', '020-43214321', 'companyFax');
INSERT INTO `basicinfoes` VALUES ('8', '天河区中山路XX号', 'companyAddress');



-- ----------------------------
-- Records of contracts
-- ----------------------------


-- ----------------------------
-- Records of customers
-- ----------------------------
INSERT INTO `customers` VALUES ('1', '123456', '192.168.1.123', '2014-12-12 21:43:13', '1',null,null,null);


-- ----------------------------
-- Records of feedbacks
-- ----------------------------
INSERT INTO `feedbacks` VALUES ('1', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '2', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('2', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '2', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('3', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '1', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('4', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '1', '1', '12345678932', '2014-12-12 21:42:49');
INSERT INTO `feedbacks` VALUES ('5', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试', '1', '1', '12345678932', '2014-12-12 21:42:49');



-- ----------------------------
-- Records of producttypes
-- ----------------------------
INSERT INTO `producttypes` VALUES ('1', 'Power Trasformer', '-1', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('2', 'Dry type Power Trasformer', '1', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('3', 'Oil Immersed Power Trasformer', '1', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('4', 'Switchgear', '-1', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('5', 'High Voltage Switchgear', '4', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('6', 'Low Voltage Switchgear', '4', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('7', 'Europea type Box Substatio', '13', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('8', 'America type Box Substatio', '13', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('9', 'Box Substatio', '-1', 'sa', '2014-01-01 00:00:00', '1');
INSERT INTO `producttypes` VALUES ('10', 'Electrical products', '-1', 'sa', '2014-01-01 00:00:00', '1');

-- ----------------------------
-- Records of products
-- ----------------------------
INSERT INTO `products` VALUES ('1', '123', '123', '123', '123', '1', '2014-12-14 20:57:41');


-- ----------------------------
-- Records of recruitments
-- ----------------------------


-- ----------------------------
-- Records of userinfoes
-- ----------------------------
INSERT INTO `userinfoes` VALUES ('117', 'Jason', 'Jason@mail.com', 'E10ADC3949BA59ABBE56E057F20F883E', '2014-11-23 20:15:33', '2014-12-12 21:00:10', '12345678901', '0', '0', '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17');
INSERT INTO `userinfoes` VALUES ('118', 'test', 'test@163.com', 'E10ADC3949BA59ABBE56E057F20F883E', '2014-12-07 20:19:47', '0001-01-01 00:00:00', '12345645645', '0', '0', null);


-- ----------------------------
-- Records of visitlogs
-- ----------------------------