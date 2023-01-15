using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp4MvcNuevo.Models;
using System.Text;
using Tp4MvcNuevo.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace Tp4MvcNuevo.Controllers;

public class LogueoController : Controller {
    private readonly IRepositorioUsuarios repoUsuarios;
    private readonly IMapper mapper;

    public LogueoController(IMapper map, IRepositorioUsuarios repo) {
        repoUsuarios = repo;
        mapper = map;
    }
}