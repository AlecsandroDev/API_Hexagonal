# API Hexagonal

### Nome: Alecsandro Costa Santos
### RA: 1986042
### Turma: BCC-C

---
Rotas:
```
  /Aluno
    GET /Aluno/GetAlunoAll | Retorna todos os alunos cadastrados | nenhum
    GET /Aluno/GetAluno/{id} | Retorna um aluno específico | id (Guid)
    POST /Aluno/MatricularAluno | Cadastra e matricula um novo aluno em um curso | firstName (string), email (string), cursoId (Guid)
    PUT /Aluno/EditAluno/{id} | Atualiza os dados de um aluno existente | id (Guid), firstName (string), email (string)
    DELETE /Aluno/DeleteAluno/{id} | Remove um aluno do sistema | id (Guid)

  /Curso
    GET /Curso/GetCursoAll | Retorna todos os cursos cadastrados | nenhum
```
