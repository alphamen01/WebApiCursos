﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApiCursos.Models
{
	public class Course
	{
		[Key]
		[Required]
		[Display(Name = "CourseId")]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre es requerido")]
		[Display(Name = "Nombre")]
		[MaxLength(150)]
		public string Name { get; set; }

		[MaxLength(500, ErrorMessage = "El numero maximo de caracteres permitido es 500")]
		[Required]
		[Display(Name = "Descripcion")]
		public string Description { get; set; }

		[Required(ErrorMessage = "El(La) docente es requerido(a)")]
		[MaxLength(150)]
		[Display(Name = "Docente")]
		public string Teacher { get; set; }

		[Url(ErrorMessage = "La direccion no es valida")]
		[MaxLength(150)]
		[Display(Name = "Url")]
		[Required]
		public string Uri { get; set; }
	}
}
