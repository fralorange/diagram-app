﻿namespace DiagramApp.Contracts.Canvas.Figures
{
    public class PathTextFigureDto : PathFigureDto
    {
        public required string Text { get; set; }
        public required double FontSize { get; set; }
    }
}
