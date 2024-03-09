using System.Collections.Generic;
using System.Web.Mvc;

public class TarefaController : Controller
{
    private static List<Tarefa> tarefas = new List<Tarefa>();

    public ActionResult Index()
    {
        return View(tarefas);
    }

    [HttpPost]
    public ActionResult Adicionar(string descricao)
    {
        tarefas.Add(new Tarefa { Id = tarefas.Count + 1, Descricao = descricao, Concluida = false });
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Concluir(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa != null)
            tarefa.Concluida = true;
        return RedirectToAction("Index");
    }
}
