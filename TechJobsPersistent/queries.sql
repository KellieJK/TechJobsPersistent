--Part 1
CREATE TABLE jobs (
   Id int,
   Name varchar,
   EmployerId int
);

--Part 2
SELECT Name FROM Employers WHERE Location = "St. Louis City";
--Part 3

SELECT * FROM Skills
	LEFT JOIN JobSkills ON Skill.Id = JobSkills.SkillId
	WHERE JobSkills.JobId IS NOT NULL
	ORDER BY name ASC;