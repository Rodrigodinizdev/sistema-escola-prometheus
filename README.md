# sistema-escola-prometheus
Tarefa – Modelagem e Banco de Dados: Sistema Acadêmico Prometheus
Regra de negócio: Colégio Técnico Prometheus
O Colégio Técnico Prometheus é uma instituição de ensino que funciona há mais de vinte anos formando profissionais nas áreas de tecnologia e gestão. Com o crescimento do número de alunos e professores, a direção decidiu modernizar sua gestão acadêmica com um sistema desenvolvido internamente.

Toda pessoa vinculada ao colégio — seja ela um aluno ou um professor — possui informações em comum: um nome completo, uma data de nascimento e um CPF único que a identifica no sistema. No entanto, alunos e professores existem de formas distintas dentro da instituição e carregam informações e responsabilidades bem diferentes entre si.

Quando um professor é contratado pelo Prometheus, ele recebe automaticamente um número de registro funcional, que é único e sequencial dentro do sistema. Além disso, cada professor possui uma área de especialização, que representa o campo do conhecimento no qual ele atua — por exemplo, "Matemática", "Programação" ou "Gestão de Projetos". Um professor pode ser responsável por uma ou mais disciplinas.

Já um aluno, ao ser matriculado, recebe automaticamente um número de matrícula único e sequencial. Junto à matrícula, o sistema também registra a data de ingresso do aluno na instituição. Um aluno pode estar vinculado a várias disciplinas.

As disciplinas do Prometheus possuem um nome e uma carga horária em horas. Cada disciplina obrigatoriamente tem um professor responsável, sem o qual ela não pode ser cadastrada no sistema. A mesma disciplina não pode ter dois professores responsáveis ao mesmo tempo.

Quanto à avaliação dos alunos, o Prometheus adota um modelo com dois tipos distintos de instrumentos avaliativos: as Avaliações Teóricas e as Avaliações Práticas. Ambas registram um título descritivo, a data de realização e a nota obtida pelo aluno — que deve estar obrigatoriamente entre 0,0 e 10,0. A diferença entre elas está no peso que cada uma carrega no cálculo da média final do aluno em uma disciplina: uma Avaliação Teórica contribui com 60% do valor, enquanto uma Avaliação Prática contribui com 40%. Um aluno deverá possuir uma Avaliação Teórica e uma Avaliação Prática por disciplina.

O sistema precisa ser capaz de, a qualquer momento, listar todos os alunos, professores e disciplinas cadastradas. Também deve ser possível buscar um aluno pelo nome — mesmo que a busca seja parcial, o sistema deve retornar todos os alunos cujo nome contenha o trecho digitado, sem distinção entre maiúsculas e minúsculas.

Uma funcionalidade muito valorizada pela coordenação é o Ranking Geral dos Alunos por Disciplina: dado o nome de uma disciplina, o sistema deve listar todos os alunos que possuem ao menos uma avaliação naquela disciplina, exibindo suas médias calculadas e ordenando-os do maior para o menor desempenho. Alunos sem nenhuma avaliação naquela disciplina não devem aparecer no ranking.

Além do ranking, o sistema deve oferecer um Boletim Individual: ao selecionar um aluno, o sistema exibe todas as disciplinas em que ele possui avaliações, com suas respectivas notas, a média calculada e a situação final. A situação segue a seguinte regra: se a média for maior ou igual a 7,0, o aluno está aprovado; se for maior ou igual a 5,0 e menor que 7,0, está em recuperação; caso contrário, está reprovado. As disciplinas no boletim devem ser exibidas em ordem alfabética.

Por fim, a coordenação também quer poder filtrar alunos por situação em uma determinada disciplina — ou seja, dado o nome de uma disciplina, o sistema deve conseguir exibir separadamente os alunos Aprovados, os em Recuperação e os Reprovados, cada grupo ordenado alfabeticamente pelo nome do aluno.

Todo o funcionamento do sistema se dá por meio de um menu interativo no console, que permanece ativo até que o usuário escolha explicitamente a opção de encerramento.

Objetivo
Desenvolver a estrutura de dados para o sistema de gestão acadêmica, aplicando conceitos de:

Modelagem de dados
Banco de dados relacional
Etapas da Atividade
Etapa 1 – Modelagem de Dados
Você deverá:

Identificar as entidades do sistema
Definir atributos e tipos de dados
Criar os relacionamentos entre as entidades
Entrega obrigatória:

Diagrama ER
Etapa 2 – Banco de Dados
Com base na modelagem:

Criar o banco de dados relacional
Criar tabelas com:
Chaves primárias
Chaves estrangeiras
Restrições de integridade
Regras obrigatórias:

CPF deve ser único
Matrícula e registro funcional devem ser únicos
Nota deve estar entre 0 e 10
Toda disciplina deve ter um professor
Toda avaliação deve estar vinculada a um aluno e a uma disciplina
Entrega
Script SQL de criação do banco
Diagrama ER
