# Descrição das Imagens:
### Explicando o que está sendo realizado na imagem capturada do Postman:

  Aluno:
  - GET /Aluno/GetAlunoAll | Endpoint GET retornando a lista de todos os alunos matriculados, com seus respectivos cursos carregados corretamente no JSON (Status 200 OK).
  - GET /Aluno/GetAluno/{id} | Endpoint GET buscando um aluno específico por ID. Demonstra o relacionamento funcionando corretamente, trazendo o nome do curso vinculado (Status 200 OK).
  - POST /Aluno/MatricularAluno | Endpoint POST demonstrando a criação de um novo registro de aluno associado a um curso válido (Status 200 OK).
  - POST /Aluno/MatricularAluno (ErroCurso) | Teste de validação no POST (Status 400 Bad Request), bloqueando a matrícula de um aluno em um cursoId que não existe no banco de dados.
  - POST /Aluno/MatricularAluno (ErroEmail) | Teste de regra de negócio no POST (Status 400 Bad Request), bloqueando o cadastro de um e-mail que não possui o domínio obrigatório @faculdade.edu.
  - POST /Aluno/MatricularAluno (ErroNome) | Teste de validação de limite de caracteres no POST (Status 400 Bad Request), impedindo o cadastro caso o campo firstName ultrapasse 50 caracteres.
  - PUT /Aluno/EditAluno/{id} | Endpoint PUT atualizando os dados cadastrais (nome e e-mail) de um aluno existente com sucesso (Status 200 OK).
  - DELETE /Aluno/DeleteAluno/{id} | Endpoint DELETE demonstrando a exclusão de um aluno do sistema através do seu ID com mensagem de sucesso (Status 200 OK).
  
  Curso:
  - GET /Curso/GetCursoAll | Endpoint GET retornando a lista de todos os cursos cadastrados no banco de dados com sucesso (Status 200 OK).
