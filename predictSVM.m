function predictions = predictSVM(models, X)
    predictions = zeros(size(X, 1), 1);
    for i = 1:size(X, 1)
        scores = zeros(length(models), 1);
        for j = 1:length(models)
            scores(j) = dot(models(j).w, X(i, :)) + models(j).b;
        end
        [~, predictions(i)] = max(scores);
    end
end
