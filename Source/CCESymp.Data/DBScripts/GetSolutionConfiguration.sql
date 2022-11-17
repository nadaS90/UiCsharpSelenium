select [Configuration] from [Symphony].[Configuration] as C Inner JOIN Symphony.Solution as S ON C.SolutionId = S.Id
  where S.Name = @solutionname